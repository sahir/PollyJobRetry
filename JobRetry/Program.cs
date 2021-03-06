﻿using Polly;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace JobRetry
{
    class Program
    {
        static void Main(string[] args)
        {
            Getretrypolicyhandler().Execute(() =>
            {
                //write the code you want to retry
            });
        }

        public static Policy Getretrypolicyhandler()
        {
            Policy retrywithexponentialbackoff = Policy.Handle<Exception>().WaitAndRetry(new[]
            {
                TimeSpan.FromSeconds(30),
                TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(16)),
                TimeSpan.FromMinutes(2).Add(TimeSpan.FromSeconds(32)),
                TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(8)),
                TimeSpan.FromMinutes(10).Add(TimeSpan.FromSeconds(54)),
                TimeSpan.FromMinutes(23).Add(TimeSpan.FromSeconds(4)),
                TimeSpan.FromMinutes(46).Add(TimeSpan.FromSeconds(40)),
                TimeSpan.FromHours(1).Add(TimeSpan.FromMinutes(28)).Add(TimeSpan.FromSeconds(56)),
                TimeSpan.FromHours(2).Add(TimeSpan.FromMinutes(39)).Add(TimeSpan.FromSeconds(42)),
                TimeSpan.FromHours(4).Add(TimeSpan.FromMinutes(31)).Add(TimeSpan.FromSeconds(48)),
                TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(21)).Add(TimeSpan.FromSeconds(28)),
                TimeSpan.FromHours(11).Add(TimeSpan.FromMinutes(28)).Add(TimeSpan.FromSeconds(44)),
                TimeSpan.FromHours(17).Add(TimeSpan.FromMinutes(17)).Add(TimeSpan.FromSeconds(50)),
                TimeSpan.FromDays(1).Add(TimeSpan.FromHours(1)).Add(TimeSpan.FromMinutes(17)).Add(TimeSpan.FromSeconds(36)),
                TimeSpan.FromDays(1).Add(TimeSpan.FromHours(12)).Add(TimeSpan.FromMinutes(1)).Add(TimeSpan.FromSeconds(52)),
                TimeSpan.FromDays(2).Add(TimeSpan.FromHours(2)).Add(TimeSpan.FromMinutes(9)).Add(TimeSpan.FromSeconds(52)),
                TimeSpan.FromDays(2).Add(TimeSpan.FromHours(20)).Add(TimeSpan.FromMinutes(26)).Add(TimeSpan.FromSeconds(38)),
                TimeSpan.FromDays(3).Add(TimeSpan.FromHours(19)).Add(TimeSpan.FromMinutes(43)).Add(TimeSpan.FromSeconds(24)),
                TimeSpan.FromDays(5).Add(TimeSpan.FromMinutes(58)).Add(TimeSpan.FromSeconds(0)),
                TimeSpan.FromDays(6).Add(TimeSpan.FromHours(13)).Add(TimeSpan.FromMinutes(15)).Add(TimeSpan.FromSeconds(16)),
                TimeSpan.FromDays(8).Add(TimeSpan.FromHours(9)).Add(TimeSpan.FromMinutes(15)).Add(TimeSpan.FromSeconds(16)),
                TimeSpan.FromDays(10).Add(TimeSpan.FromHours(15)).Add(TimeSpan.FromMinutes(47)).Add(TimeSpan.FromSeconds(26)),
                TimeSpan.FromDays(13).Add(TimeSpan.FromHours(9)).Add(TimeSpan.FromMinutes(54)).Add(TimeSpan.FromSeconds(32)),
                TimeSpan.FromDays(16).Add(TimeSpan.FromHours(14)).Add(TimeSpan.FromMinutes(28)).Add(TimeSpan.FromSeconds(48)),
                TimeSpan.FromDays(20).Add(TimeSpan.FromHours(11)).Add(TimeSpan.FromMinutes(11)).Add(TimeSpan.FromSeconds(10))});
            return retrywithexponentialbackoff;
        }
    }
}

