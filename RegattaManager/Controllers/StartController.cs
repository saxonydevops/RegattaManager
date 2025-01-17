﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegattaManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RegattaManager.Controllers
{
    [Authorize]
    public class StartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(int? id)
        {
            ViewBag.AllClubs = _context.Clubs.ToList();
            var model = _context.Races.Include(e => e.Boatclass).Include(e => e.Oldclass).Include(e => e.Raceclass).Include(e => e.Regatta).Include(e => e.Racestatus).Include(e => e.Startboats).Where(e => e.RacestatusId == 1 || e.RacestatusId == 1005).OrderBy(e => e.Starttime).FirstOrDefault();
            ViewBag.startboats = _context.Startboats.Include(e => e.Club).Include(e => e.Startboatstatus).OrderBy(e => e.Startslot).ToList();
            ViewBag.startboatmembers = _context.StartboatMembers.ToList();
            ViewBag.members = _context.Members.ToList();
            ViewBag.raceid = id;
            ViewBag.currentTime = System.DateTime.Now;
            var readyracescount = _context.Races.Include(e => e.Boatclass).Include(e => e.Oldclass).Include(e => e.Raceclass).Include(e => e.Regatta).Include(e => e.Racestatus).Include(e => e.Startboats).Where(e => e.RacestatusId == 1 || e.RacestatusId == 1005).OrderBy(e => e.Starttime).Count();            
            ViewBag.ReadyRacesCount = readyracescount;

            if(readyracescount > 1)
            {
                ViewBag.ReadyRaces = new SelectList(_context.Races.Include(e => e.Boatclass).Include(e => e.Oldclass).Include(e => e.Raceclass).Include(e => e.Regatta).Include(e => e.Racestatus).Include(e => e.Startboats).Where(e => (e.RacestatusId == 1 || e.RacestatusId == 1005) && e.RaceId != model.RaceId).OrderBy(e => e.Starttime).Take(10).ToList(), "RaceId", "Starttime.TimeOfDay");            
            }

            ViewBag.NextRaces = _context.Races.Include(e => e.Boatclass).Include(e => e.Oldclass).Include(e => e.Raceclass).Include(e => e.Regatta).Include(e => e.Racestatus).Include(e => e.Startboats).Where(e => e.RacestatusId == 1 || e.RacestatusId == 1005).OrderBy(e => e.Starttime).Take(5).ToList();

            if(id != null)
            {
                model = _context.Races.Include(e => e.Boatclass).Include(e => e.Oldclass).Include(e => e.Raceclass).Include(e => e.Regatta).Include(e => e.Racestatus).Include(e => e.Startboats).Where(e => e.RacestatusId == 1 || e.RacestatusId == 1005).OrderBy(e => e.Starttime).FirstOrDefault(e => e.RaceId == id);

                ViewBag.allClicked = true;
                ViewBag.NextRaces = _context.Races.Include(e => e.Boatclass).Include(e => e.Oldclass).Include(e => e.Raceclass).Include(e => e.Regatta).Include(e => e.Racestatus).Include(e => e.Startboats).Where(e => (e.RacestatusId == 1 || e.RacestatusId == 1005) && e.RaceId != model.RaceId).OrderBy(e => e.Starttime).Take(5).ToList();

                if (_context.Startboats.Any(e => e.RaceId == model.RaceId && e.StartboatstatusId == 6))
                {
                    ViewBag.allClicked = false;
                }

                return View(model);
            }

            if (model != null)
            {
                ViewBag.allClicked = true;
                ViewBag.NextRaces = _context.Races.Include(e => e.Boatclass).Include(e => e.Oldclass).Include(e => e.Raceclass).Include(e => e.Regatta).Include(e => e.Racestatus).Include(e => e.Startboats).Where(e => (e.RacestatusId == 1 || e.RacestatusId == 1005) && e.RaceId != model.RaceId).OrderBy(e => e.Starttime).Take(5).ToList();

                if(_context.Startboats.Any(e => e.RaceId == model.RaceId && e.StartboatstatusId == 6))
                {
                    ViewBag.allClicked = false;
                }

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult VerifyStartboat(int id, int statusid, int raceid)
        {
            var startboat = _context.Startboats.FirstOrDefault(e => e.StartboatId == id);
            startboat.StartboatstatusId = statusid;
            if (ModelState.IsValid)
            {
                _context.Entry(startboat).State = EntityState.Modified;
                _context.SaveChanges();
            }
                        
            return Redirect(Url.RouteUrl(new { controller = "Start", action = "Index" }) + "?id=" + raceid + "#" + id);
        }

        [HttpPost]
        public IActionResult VerifyAllStartboats(int id, int statusid)
        {
            var race = _context.Races.FirstOrDefault(e => e.RaceId == id);
            var startboats = _context.Startboats.Where(e => e.RaceId == id).ToList();

            foreach(var sb in startboats)
            {
                sb.StartboatstatusId = statusid;

                if (ModelState.IsValid)
                {
                    _context.Entry(sb).State = EntityState.Modified;                    
                }
            }

            _context.SaveChanges();

            return Redirect(Url.RouteUrl(new { controller = "Start", action = "Index" }) + "?id=" + id);
        }

        [HttpGet]
        public IActionResult StartRace(int id)
        {
            var race = _context.Races.FirstOrDefault(e => e.RaceId == id);
            
            race.RacestatusId = 2;
            race.Realstarttime = System.DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Entry(race).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}