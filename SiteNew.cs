using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class SiteNew : PapaSome
    {
        private static List<string> natasha = MkNatasha();

        public static int MainSite()
        {
            string outFileName = Path.Combine(dataOutPath, "OutSite.csv");
            string outFileNamePhp = Path.Combine(dataOutPath, "page-departments.php");

            Dictionary<string, string> regimes = FileToDict(4);

            var accessClear = FileToText(Path.Combine(dataInPath, "access.csv"));
            if (exitStatus) goto LabelExit;
            var accessOld = FileToText(Path.Combine(dataInPath, "access_old.csv"));
            if (exitStatus) goto LabelExit;
            CopyOneFile(Path.Combine(dataInPath, "access.csv"), Path.Combine(dataInPath, "access_old.csv"));
            if (exitStatus) goto LabelExit;
            if (accessClear == accessOld) { infoSmall = " No change ! \n" + infoSmall; }

            string headerClear = "Повне найменування відокремленного підрозділу;Адреса відокремленного підрозділу;Дата та номер рішення про створення відокремленого підрозділу;ЄДРПОУ;Режим роботи;Платежі приймаються в Платіжній системі;Платежі виплачуються  в Платіжній системі\n";

            string outTextPhp = "";
            string outClear = headerClear;

            var access = AccessToArr();
            if (exitStatus) goto LabelExit;

            foreach (string[] accessLine in access)
            {
                try
                {
                    if (accessLine[0].IndexOf("2(Веб-сайт-ПТКС)") > -1) { continue; }

                    string dep = "";
                    if (accessLine[0].IndexOf("№") > -1) { dep = accessLine[0].Split('№')[1]; }
                    else { dep = accessLine[0]; }
                    string regimeInsert = "Не працює";
                    if ((dep.Length > 2) && (natasha.IndexOf(dep) > -1))
                    {
                        try
                        {
                            string agSign = dep.Substring(0, 3);
                            regimeInsert = regimes[agSign];
                        }
                        catch { }
                    }

                    if (dep == "1") regimeInsert = "ПН-ПТ 09:00-18:00";

                    string edr = "";
                    if ("" != accessLine[1]) edr = accessLine[1];

                    string linePhp = String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>ВПС ЕЛЕКТРУМ</td><td>ВПС FLASHPAY, ВПС ЕЛЕКТРУМ</td></tr>", accessLine[0], accessLine[2], accessLine[3], edr, regimeInsert);
                    outTextPhp += linePhp + "\n";

                    string line = String.Format("{0};{1};{2};{3};{4};ВПС ЕЛЕКТРУМ;ВПС FLASHPAY, ВПС ЕЛЕКТРУМ", accessLine[0], accessLine[2], accessLine[3], edr, regimeInsert);
                    outClear += line + "\n";
                }
                catch
                {

                }
                
            }
            TextToFile(outFileName, outClear);
            if (exitStatus) goto LabelExit;

            string textPhp = outTextPhp;
            string text1 = FileToText("Config/SiteText1.txt");
            if (exitStatus) goto LabelExit;
            string text2 = FileToText("Config/SiteText2.txt");
            if (exitStatus) goto LabelExit;
            string fullTextPhp = text1 + textPhp + text2;
            TextToFile(outFileNamePhp, fullTextPhp);
            if (exitStatus) goto LabelExit;

            return 0;

        LabelExit:
            return 1;
        }

        private static List<string[]> AccessToArr()
        {
            List<string[]> a = FileToArr( Path.Combine(dataInPath, "access.csv") );
            foreach (string[] aa in a) { aa[0] = "ВІДДІЛЕННЯ №" + aa[0]; }

            return a;
        }

        public static bool InNatasha(string dep)
        {
            bool flag = false;
            foreach (string unit in natasha)
            {
                if (dep == unit)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

    }
}
