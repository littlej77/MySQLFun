using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySQLFun.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Controllers
{
    public class HomeController : Controller
    {
        private IBowlerRepository _repo { get; set; }

        //constructor
        public HomeController(IBowlerRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int teamId)
        {
            //var teams = _repo.Teams.ToList();

            //var blah = (bowlers, teams );
            //ViewBag.Bowlers = _repo.Bowlers.ToList();
            ViewBag.Teams = _repo.Teams.OrderBy(x => x.TeamName).ToList();
            ViewBag.TeamsTest = _repo.Teams.OrderBy(x => x.TeamName);


            var bowlers = _repo.Bowlers
                .Where(x=> x.TeamID == teamId || teamId == 0)
                .ToList();


            return View(bowlers);
        }

        public IActionResult Teams(int bowlerid)
        {
            var blue = _repo.Teams.ToList();


            return View("TeamsView",blue);
        }






        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            var entry = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            ViewBag.Teams = _repo.Teams.ToList();

            return View("Edit", entry);

        }

        [HttpPost]
        public IActionResult Edit(Bowler bwl)
        {
            _repo.EditResponse(bwl);


            return RedirectToAction("Index");

        }

        public IActionResult Add()
        {
            Bowler bwlr = new Bowler();

            ViewBag.Bowlers = _repo.Bowlers.ToList();
            ViewBag.Teams = _repo.Teams.ToList();
            return View("Edit", bwlr);
        }

        [HttpPost]
        public IActionResult Add(Bowler bwl)
        {
            //here we need to make the bowlerId and the TeamID to be created.

            
            //while (bwl.TeamID == null)
            //{
            //    if (teamname.TeamName == "Marlins")
            //    {
            //        bwl.TeamID = 1;
            //    }
            //    if (teamname.TeamName == "Sharks")
            //    {
            //        bwl.TeamID = 2;
            //    }
            //    if (teamname.TeamName == "Terrapins")
            //    {
            //        bwl.TeamID = 3;
            //    }
            //    if (teamname.TeamName == "Barracudas")
            //    {
            //        bwl.TeamID = 4;
            //    }
            //    if (teamname.TeamName == "Dolphins")
            //    {
            //        bwl.TeamID = 5;
            //    }
            //    if (teamname.TeamName == "Orcas")
            //    {
            //        bwl.TeamID = 6;
            //    }
            //    if (teamname.TeamName == "Manatees")
            //    {
            //        bwl.TeamID = 7;
            //    }
            //    if (teamname.TeamName == "Swordfish")
            //    {
            //        bwl.TeamID = 8;
            //    }
            //    if (teamname.TeamName == "Huckleberrys")
            //    {
            //        bwl.TeamID = 9;
            //    }
            //    if (teamname.TeamName == "MintJuleps")
            //    {
            //        bwl.TeamID = 10;
            //    }
            //}


            if (ModelState.IsValid)
            {
                _repo.AddResponse(bwl);

                return RedirectToAction("Index");
            }
            else // if invalid then send them back to the view with the info they had put in
            {
                ViewBag.Bowlers = _repo.Bowlers.ToList();
                ViewBag.Teams = _repo.Teams.ToList();

                return View("Edit");
            }
        }

        public IActionResult Delete(Bowler bwl)
        {
            _repo.DeleteResponse(bwl);

            return RedirectToAction("Index");
        }
    }
}
