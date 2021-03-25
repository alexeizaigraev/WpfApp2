using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class HrDep : PapaSome
    {
        public static int MainHrDep()
        {
            string myKey = "partner";
            string outText = "№ п/п;\"№ Відділення ТОВ \"\"ЕПС\"\"\";Область;Район в обл.;Індекс;Тип населеного пункту;Населений пункт;Район в місті;Тип вулиці;Адреса;Номер будинку;Дата признчення керівника;модель РРО;Заводський № РРО;2\n";
            var hh = FileToHashTab(dataInPath + "vsyo_zapros.csv", 0);
            if (exitStatus) goto LabelExit;
            //string partner = MenuColKey(hh, "partner");

            string partner = partnerChoised;
            //pCyan("\n " + partner + "\n");

            int count = 0;
            Dictionary<string, string> line = new Dictionary<string, string>();
            foreach (string key in hh.Keys)
            {
                try
                {
                    line = hh[key];

                    if (line[myKey] == partner)
                    {
                        count++;
                        string outLine = "";
                        outLine = String.Format("{0}", count) + ";"
                            + line["Терминалы.department"] + ";"
                            + line["region"] + ";"
                            + line["district_region"] + ";"
                            + line["post_index"] + ";"
                            + line["city_type"] + ";"
                            + line["city"] + ";"
                            + line["district_city"] + ";"
                            + line["street_type"] + ";"
                            + line["street"] + ";"
                            + line["hous"] + ";"
                            + "" + ";"
                            + "" + ";"
                            + "" + ";"
                            + line["address"];
                        outText += outLine + '\n';
                    }


                }
                catch { }
            }
            TextToFile(dataOutPath + "hr_new_deps.csv", outText);
            if (exitStatus) goto LabelExit;

            return 0;

        LabelExit:
            return 1;
        }

    }
}
