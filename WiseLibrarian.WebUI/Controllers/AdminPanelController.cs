﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace WiseLibrarian.WebUI.Controllers
{
    public class AdminPanelController : Controller
    {
        
        
        public ActionResult Crud()
        {
            return View();
        }
        public ActionResult ContactMessages()
        {
            return View();
        }
    }
}