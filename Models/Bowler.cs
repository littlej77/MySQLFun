﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Models
{
    public class Bowler
    {

        //First Name, Middle Init, Last Name, Address, City, State, Zip, Phone Number
        [Key]
        [Required]
        public int BowlerID { get; set; }

        public string BowlerFirstName { get; set; }
        public string BowlerLastName { get; set; }
        public string BowlerMiddleInit { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }
        public string BowlerState { get; set; }
        public string  BowlerZip { get; set; }
        public string  BowlerPhoneNumber { get; set; }

        public int TeamID { get; set; }
    }
}
