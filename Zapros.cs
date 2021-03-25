using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Zapros : Papa
    {
        public static int MainZapros()
        {
            var otbor = FileToArr(Path.Combine(dataInPath, "otbor.csv"));
            if (exitStatus) goto LabelExit;
            int countLines = -1;
            List<string> otborObjects = new List<string>();
            foreach (var otborLine in otbor)
            {
                countLines++;
                if (countLines > 0) { otborObjects.Add(otborLine[0]); }
            }


            var vsyo = FileToArr(Path.Combine(dataInPath, "vsyo_zapros.csv"));
            if (exitStatus) goto LabelExit;
            string head = String.Join(";", vsyo[0]) + "\n";
            string outText = head;

            foreach (var vsyoLine in vsyo)
            {
                //pYellow(vsyoLine[1]);
                if (otborObjects.IndexOf(vsyoLine[1]) > -1)
                {
                    outText += String.Join(";", vsyoLine) + "\n";
                    infoBig += vsyoLine[0] + "\t";
                }
            }

            TextToFile(Path.Combine(dataInPath, "vsyo_zapros_vneh_otbor.csv"), outText);
            if (exitStatus) goto LabelExit;

            return 0;

        LabelExit:
            return 1;
        }
    }
}
