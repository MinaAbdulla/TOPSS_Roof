﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Spacing
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = @"..\..\table01.txt";
            RafterTable Rtb = new RafterTable();
            Rtb.Load(s);
            Length L = new Length(5,0);
            var mtb = Rtb.Cells.Where(e => e.RafterDepth==4&&e.DeadLoad==10 &&
            e.RafterSpan.ToInch() >= L.ToInch()).OrderBy(e => e.RafterSpan.ToInch()).First();
            var mina = Rtb.Cells.Where(e => e.DeadLoad == 20
                                        && e.RafterDepth == 6
                                        && e.RafterSpacing == 16
                                        && e.Species==Species.Spruce_pine_fir
                                        ).ToList();
            var Span = Rtb.Cells.Where(e =>  e.RafterSpan.ToInch()== new Length(5,0).ToInch() 
                                         //GetSpanAsString(6,6) 
                                       // && e.RafterSpacing == 16
                                        //&& e.Species == Species.Spruce_pine_fir
                                        ).ToList();
            //var mtb = Rtb.Cells.Where(e => e.Species==Species.Douglas_fir_larch&&e.DeadLoad == 10).ToList();
           // Console.WriteLine("NO Of Results {0} \n", mina.Count());
            for (int j = 0; j < Span.Count(); j++)
            {
                Console.WriteLine(" Solution no {0} is Spacing : {1} \n Rafter Depth : {2}",j,Span[j].RafterSpacing, Span[j].RafterDepth);
                //Console.WriteLine(" this item Max Span {0}'-{1}\" \n ",mina[i].RafterSpan.Feet, mina[i].RafterSpan.Inch);
            }

            //Console.WriteLine("Done \n grade:{0}\n species : {1} \n cross-Section :2*{2}"
            //    ,mtb.Grade,mtb.Species,mtb.RafterDepth);

            Console.Read();
        }


        public static String GetSpanAsString(double feet, double inch)
        {
            string result = @"feet-inch";
            return result;
        }

    }
}
