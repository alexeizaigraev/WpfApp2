using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Term : PapaSome
    {
        private static int ColDataShablon1 = 5;
        private static int ColDataShablon2 = 6;
        private static int ColDataSoft = 7;
        private static int ColDataLimit = 8;

        private static string agCod = "";
        public static int MainTerm()
        {
            outLine = "";
            outText = "";
            string inFileName = "vsyo_zapros_vneh_otbor.csv";
            string outFileName = "OutTerminals.csv";
            Dictionary<string, Dictionary<string, string>> data = FileToHashTab(dataInPath + inFileName, 1);
            if (exitStatus) goto LabelExit;

            Dictionary<string, string> dictLine;
            foreach (string key in data.Keys)
            {
                dictLine = data[key];
                string terminal = dictLine["termial"];
                string idd;
                if (dictLine["id_terminal"] != "") { idd = dictLine["id_terminal"]; }
                else { idd = terminal; }

                string sity = dictLine["city"];
                string region = dictLine["region"];
                if (region == "")
                    region = sity;
                string street = dictLine["street"];
                string house = dictLine["hous"];

                string serial = "";
                string serial0 = dictLine["serial_number"].Substring(2, dictLine["serial_number"].Length - 2);
                int startZero = -1;
                foreach (char c in serial0)
                {
                    if ('0' == c) { startZero += 1; }
                    else { break; }
                }

                serial = serial0.Substring(startZero + 1, serial0.Length - startZero - 1);

                agCod = terminal.Substring(0, 3);

                outLine = terminal + ";" +
                        idd + ";" +
                        DefAgent()["shablon1"] + ";" +
                        sity + ", " + region + ";" +
                        street + ", " + house + ";" +
                        DefAgent()["shablon2"] + ";" +
                        DefAgent()["soft"] + ";" +
                        DefAgent()["limit"] + ";" +
                        serial;

                if (exitStatus) goto LabelExit;
                outText += outLine + "\n";
                //pBlue(outLine);

            }
            TextToFile(dataOutPath + outFileName, outText);
            if (exitStatus) goto LabelExit;

            infoSmall = dataOutPath + outFileName;
            infoBig = outText;

            return 0;

        LabelExit:
            return 1;
        }

        private static Dictionary<string, string> DefAgent()
        {
            Dictionary<string, string> h = new Dictionary<string, string>()
            {
                { "shablon1", "" },
                { "shablon2", ""},
                { "soft", "" },
                { "limit", "" },
            };

            List<string[]> a = FileToArr(myDataPath);
            foreach (string[] vec in a)
            {
                if (vec[0].IndexOf(agCod) > -1)
                {
                    h["shablon1"] = vec[ColDataShablon1];
                    h["shablon2"] = vec[ColDataShablon2];
                    h["soft"] = vec[ColDataSoft];
                    h["limit"] = vec[ColDataLimit];
                    break;
                }
            }
            if ("shablon1" == h["shablon1"])
                Sos("Незнакомый агент", agCod);

            return h;
        }
    }
}
