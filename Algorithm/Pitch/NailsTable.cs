﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Algo.Pitch
    {
        public class NailsTable
        {
            public static string pFilePath { get; set; }
            public List<NailsCell> nailsCells { get; set; }
            public NailsTable()
            {
                nailsCells = new List<NailsCell>();
            }
            public void Load(string filePath)
            {
                string[] Data = File.ReadAllLines(filePath);
                //var RoofSpan_P = Data[0].Split(',');
                var RoofSpan_P = Data[0].Split(',');
                var RafterPitch = Data[1].Split(',');
                var GrSnowLoad = Data[2].Split(',');
                var RafterSpacing_p = Data[3].Split(',');
                //RafterPitch[] Rpitch = { RafterPitch._3, RafterPitch._4, RafterPitch._5,
                //                          RafterPitch._7, RafterPitch._9, RafterPitch._12 };
                //GrSnowLoad[] GSnowLoad = { GrSnowLoad._209, GrSnowLoad._30, GrSnowLoad._50, GrSnowLoad._70 };
                //RafterSpacing_p[] RafSpacing = { RafterSpacing_p._12, RafterSpacing_p._16, RafterSpacing_p._24 };
                var values = Data.Skip(4).ToArray();
                for (int j = 0; j < values.Length; j++)
                {
                    var lineSplited = values[j].Split(' ');
                    for (int i = 0; i < lineSplited.Length; i++)
                    {
                        //var ValuesSplitted = values[i].Split(' ');
                        nailsCells.Add(new NailsCell()
                        {
                            RafterPitch = GetPitch(RafterPitch[j / 3]),
                            RoofSpan_P = Convert.ToInt32(RoofSpan_P[i % 4]),
                            GrSnowLoad = GetSnowLoad(GrSnowLoad[i / 4]),
                            RafterSpacing_p = GetRafterSpacing_P(RafterSpacing_p[j % 3]),
                            NailsNo = Convert.ToInt32(lineSplited[i])
                        });
                    }
                }
            }
            //public List<int> GetNailsNo(int rafetrPitch,double rafterSpacing , double grSnowLoad,int roofSpan_P)
            //{
            //return nailsCells.Where(e => e.RafterPitch == rafetrPitch &&
            //                             e.RafterSpacing_p == rafterSpacing &&
            //                             e.RoofSpan_P == rafterSpacing)
            //                             .Select(v => v.NailsNo).ToList();}
            private RafterPitch GetPitch(string value)
            {
                foreach (RafterPitch roofPitch in Enum.GetValues(typeof(RafterPitch)))
                {
                    if (roofPitch.ToString().ToLower().Contains(value.ToLower()))
                    {
                        return roofPitch;
                    }
                }
                return RafterPitch._12;
            }
            private GrSnowLoad GetSnowLoad(string value)
            {
                foreach (GrSnowLoad snowCase in Enum.GetValues(typeof(GrSnowLoad)))
                    if (snowCase.ToString().ToLower().Contains(value.ToLower()))
                        return snowCase;

                return GrSnowLoad._209 ;
            }
            private RafterSpacing_p GetRafterSpacing_P(string value)
            {
                foreach (RafterSpacing_p rafterSpacing in Enum.GetValues(typeof(RafterSpacing_p)))
                    if (rafterSpacing.ToString().ToLower().Contains(value.ToLower()))
                        return rafterSpacing;
                return RafterSpacing_p._12;
            }
        }
    }
