using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Otbor : Papa
    {
        public static string otborChoise;
        public static int MainOtbor()
        {
            exitStatus = false;
            string choise = otborChoise;
            string outText = "term;dep\n";
            int start = 0;
            int finish = 0;
            if (choise.IndexOf(" ") > -1)
            {
                string[] choiseSplit = choise.Split(' ');
                if (choiseSplit[0].Length != 7 || choiseSplit[1].Length != 7) Sos("Bed dep", choise);
                if (exitStatus) goto LabelExit;
                start = Convert.ToInt32(choiseSplit[0]);
                finish = Convert.ToInt32(choiseSplit[1]);
            }
            else
            {
                if (choise.Length != 7) Sos("Bed dep", choise);
                if (exitStatus) goto LabelExit;
                start = Convert.ToInt32(choise);
                finish = start;
            }
            string depStr = "";
            string termStr = "";
            string outLine = "";
            for (int x = start; x <= finish; x++)
            {
                depStr = x.ToString();
                termStr = (x * 10 + 1).ToString();
                outLine = termStr + ";" + depStr;
                outText += outLine + "\n";
                infoBig += outLine + "\t";
            }
            TextToFile(Path.Combine(dataInPath, "otbor.csv"), outText);

            return 0;

        LabelExit:
            return 1;

        }

    }
}
