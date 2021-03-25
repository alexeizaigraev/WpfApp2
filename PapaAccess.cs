using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class PapaAccess
    {
        //public static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = R:\DRM\Access\db2.accdb";
        //private OleDbConnection myConnection;
        
        protected static void AccessMain()
        {
            string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = R:\DRM\Access\db2.accdb";
            OleDbConnection myConnection;
            
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            string ofName = "vsyo_zapros.csv";
            ClearMe();
            textBox1.Text = "wait...";

            OleDbConnection connection = new OleDbConnection(connectString);
            try
            {
                string outText = "Терминалы.department;termial;model;serial_number;date_manufacture;soft;producer;rne_rro;sealing;fiscal_number;oro_serial;oro_number;ticket_serial;ticket_1sheet;ticket_number;sending;books_arhiv;tickets_arhiv;to_rro;owner_rro;Отделения.department;region;district_region;city_type;city;district_city;street_type;street;hous;post_index;partner;status;register;edrpou;address;partner name;id_terminal;koatu;tax_id\n";
                string query = "SELECT Терминалы.department, Терминалы.termial, Терминалы.model, Терминалы.serial_number, Терминалы.date_manufacture, Терминалы.soft, Терминалы.producer, Терминалы.rne_rro, Терминалы.sealing, Терминалы.fiscal_number, Терминалы.oro_serial, Терминалы.oro_number, Терминалы.ticket_serial, Терминалы.ticket_1sheet, Терминалы.ticket_number, Терминалы.sending, Терминалы.books_arhiv, Терминалы.tickets_arhiv, Терминалы.to_rro, Терминалы.owner_rro, Отделения.department, Отделения.region, Отделения.district_region, Отделения.city_type, Отделения.city, Отделения.district_city, Отделения.street_type, Отделения.street, Отделения.hous, Отделения.post_index, Отделения.partner, Отделения.status, Отделения.register, Отделения.edrpou, Отделения.address, Отделения.[partner name], Отделения.id_terminal, Отделения.koatu, Отделения.tax_id FROM Терминалы INNER JOIN Отделения ON Терминалы.department = Отделения.department ORDER BY Терминалы.termial;";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string myLine = reader[0].ToString() + ";" + reader[1].ToString() + ";" + reader[2].ToString() + ";" + reader[3].ToString() + ";" + reader[4].ToString() + ";" + reader[5].ToString() + ";" + reader[6].ToString() + ";" + reader[7].ToString() + ";" + reader[8].ToString() + ";" + reader[9].ToString() + ";" + reader[10].ToString() + ";" + reader[11].ToString() + ";" + reader[12].ToString() + ";" + reader[13].ToString() + ";" + reader[14].ToString() + ";" + reader[15].ToString() + ";" + reader[16].ToString() + ";" + reader[17].ToString() + ";" + reader[18].ToString() + ";" + reader[19].ToString() + ";" + reader[20].ToString() + ";" + reader[21].ToString() + ";" + reader[22].ToString() + ";" + reader[23].ToString() + ";" + reader[24].ToString() + ";" + reader[25].ToString() + ";" + reader[26].ToString() + ";" + reader[27].ToString() + ";" + reader[28].ToString() + ";" + reader[29].ToString() + ";" + reader[30].ToString() + ";" + reader[31].ToString() + ";" + reader[32].ToString() + ";" + reader[33].ToString() + ";" + reader[34].ToString() + ";" + reader[35].ToString() + ";" + reader[36].ToString() + ";" + reader[37].ToString() + ";" + reader[38].ToString();
                    outText += myLine + "\n";
                }
                File.WriteAllText(System.IO.Path.Combine("R:/DRM/Access/Data/InData", ofName), outText);
                connection.Close();
                 = "~ " + ofName;

            }
            catch
            {
                textBox1.Text = "connect error";
                if (connection.State == ConnectionState.Open) { connection.Close(); }
            }
            finally
            {
                if (connection.State == ConnectionState.Open) { connection.Close(); }
            }
        }
    }
}
