using System;

using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db2.accdb;";
        /*
        public static string connectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = R:\DRM\Access\db2.accdb";
        private OleDbConnection myConnection;
        */
        private string agents = "";
        
        public MainWindow()
        {
            InitializeComponent();
            /*
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            */
        }
        private void ClearMe()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBoxAgChoise.Text = "";
            Papa.infoBig = "";
            Papa.infoSmall = "";
        }

        private void ButtonPriem_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            try
            {
                int x = Priem.MainPriem();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonOtpusk_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Otpusk.MainOtpusk();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonPerevod_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Perevod.MainPerevod();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonPostAll_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = PostAll.MainPostAll();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonTerm_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Term.MainTerm();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonHrDep_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = HrDep.MainHrDep();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonSite_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = SiteNew.MainSite();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonNatasha_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Natasha.MainNatasha();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonAllo_Click(object sender, RoutedEventArgs e)
        {
            Papa.partnerChoised = "allo";
            ClearMe();
            int x = 0;
            try
            {
                x = HrDep.MainHrDep();
                textBox1.Text = Papa.partnerChoised + " " + Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonDelivery_Click(object sender, RoutedEventArgs e)
        {
            Papa.partnerChoised = "Делівері Авто";
            ClearMe();
            int x = 0;
            try
            {
                x = HrDep.MainHrDep();
                textBox1.Text = Papa.partnerChoised + " " + Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonJustin_Click(object sender, RoutedEventArgs e)
        {
            Papa.partnerChoised = "Джаст Ін";
            ClearMe();
            int x = 0;
            try
            {
                x = HrDep.MainHrDep();
                textBox1.Text = Papa.partnerChoised + " " + Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonSat_Click(object sender, RoutedEventArgs e)
        {
            Papa.partnerChoised = "Сат";
            ClearMe();
            int x = 0;
            try
            {
                x = HrDep.MainHrDep();
                textBox1.Text = Papa.partnerChoised + " " + Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonOtbor_Click(object sender, RoutedEventArgs e)
        {
            Otbor.otborChoise = textBox3.Text;
            ClearMe();
            int x = 0;
            try
            {
                x = Otbor.MainOtbor();
                textBox1.Text = "wait... " + Papa.infoSmall;
                textBox2.Text = "wait... " + Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
            try
            {
                x = Zapros.MainZapros();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = "";
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonZapros_Click(object sender, RoutedEventArgs e)
        {
            /*
            string query = "SELECT Терминалы.department AS Терминалы_department, Терминалы.termial, Терминалы.model, Терминалы.serial_number, Терминалы.date_manufacture, Терминалы.soft, Терминалы.producer, Терминалы.rne_rro, Терминалы.sealing, Терминалы.fiscal_number, Терминалы.oro_serial, Терминалы.oro_number, Терминалы.ticket_serial, Терминалы.ticket_1sheet, Терминалы.ticket_number, Терминалы.sending, Терминалы.books_arhiv, Терминалы.tickets_arhiv, Терминалы.to_rro, Терминалы.owner_rro, Отделения.department AS Отделения_department, Отделения.region, Отделения.district_region, Отделения.district_city, Отделения.city_type, Отделения.city, Отделения.street, Отделения.street_type, Отделения.hous, Отделения.post_index, Отделения.partner, Отделения.status, Отделения.register, Отделения.edrpou, Отделения.address, Отделения.[partner name], Отделения.id_terminal, Отделения.koatu, Отделения.tax_id FROM (Отделения INNER JOIN Терминалы ON Отделения.[department] = Терминалы.[department]) INNER JOIN Otbor ON Терминалы.termial = Otbor.term ORDER BY Терминалы.termial;";
            string ofName = "vsyo_zapros_vnesh_otbor.csv";
            string outText = "";
            AccessProcess(query, ofName, outText);
            */
        }

        private void ButtonKnigi_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Knigi.MainKnigi();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonRro_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Rro.MainRro();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonPereezd_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Pereezd.MainPereezd();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonOtmena_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Otmena.MainOtmena();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }


        private void ButtonRasklad_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Rasklad.MainRasklad();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonAccBack_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = AccBack.MainAccBack();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonMonitor_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            int x = 0;
            try
            {
                x = Monitor.MainMonitor();
                textBox1.Text = Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            textBox3.Text = "";
        }

        private void ButtonBase_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            AccBase.AccGetAll();
            textBox1.Text += "~ " + Papa.infoSmall;
            /*
            string query = "SELECT Терминалы.department, Терминалы.termial, Терминалы.model, Терминалы.serial_number, Терминалы.date_manufacture, Терминалы.soft, Терминалы.producer, Терминалы.rne_rro, Терминалы.sealing, Терминалы.fiscal_number, Терминалы.oro_serial, Терминалы.oro_number, Терминалы.ticket_serial, Терминалы.ticket_1sheet, Терминалы.ticket_number, Терминалы.sending, Терминалы.books_arhiv, Терминалы.tickets_arhiv, Терминалы.to_rro, Терминалы.owner_rro, Отделения.department, Отделения.region, Отделения.district_region, Отделения.city_type, Отделения.city, Отделения.district_city, Отделения.street_type, Отделения.street, Отделения.hous, Отделения.post_index, Отделения.partner, Отделения.status, Отделения.register, Отделения.edrpou, Отделения.address, Отделения.[partner name], Отделения.id_terminal, Отделения.koatu, Отделения.tax_id FROM Терминалы INNER JOIN Отделения ON Терминалы.department = Отделения.department ORDER BY Терминалы.termial;";
            string ofName = "vsyo_zapros.csv";
            string outText = "Терминалы.department;termial;model;serial_number;date_manufacture;soft;producer;rne_rro;sealing;fiscal_number;oro_serial;oro_number;ticket_serial;ticket_1sheet;ticket_number;sending;books_arhiv;tickets_arhiv;to_rro;owner_rro;Отделения.department;region;district_region;city_type;city;district_city;street_type;street;hous;post_index;partner;status;register;edrpou;address;partner name;id_terminal;koatu;tax_id\n";
            AccessProcess(query, ofName, outText);           
            */
        }

        private void ButtonAccSite_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            AccBase.AccGetAccess();
            textBox2.Text = "~ " + Papa.infoSmall + "\t\n";

            SiteNew.MainSite();
            textBox1.Text = Papa.infoSmall + "\t\n" + Papa.infoBig;
            textBox2.Text += "\n" + textBox1.Text;

            /*
            string query = "SELECT * FROM ACCESS ORDER BY department; ";
            string ofName = "access.csv";
            ofName = System.IO.Path.Combine("R:/DRM/Access/Data/InData", ofName);
            string outText = "";
            AccessProcess(query, ofName, outText);
            
            SiteNew.MainSite();
            textBox1.Text += " -> " + Papa.infoSmall;
            */
        }

        private void ButtonDeps_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            AccBase.AccGetDeps();
            textBox1.Text += "~ " + Papa.infoSmall;
            /*
            string query = "SELECT * FROM Отделения ORDER BY department; ";
            string ofName = "departments.csv";
            ofName = System.IO.Path.Combine("R:/DRM/Access/Data/InData", ofName);
            string outText = "";
            AccessProcess(query, ofName, outText);
            */
        }

        private void ButtonTerms_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            AccBase.AccGetTerms();
            textBox1.Text += "~ " + Papa.infoSmall;
            /*
            string query = "SELECT * FROM Терминалы ORDER BY termial; ";
            string ofName = "terminals.csv";
            ofName = System.IO.Path.Combine("R:/DRM/Access/Data/InData", ofName);
            string outText = "";
            AccessProcess(query, ofName, outText);
            */
        }
/*
        private void AccessProcess(string query, string ofName, string header)
        {
            string outText = "";
            ClearMe();
            textBox1.Text = "wait...";

            OleDbConnection connection = new OleDbConnection(connectString);
            try
            {
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string myLine = "";
                    for( int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            if (i < reader.FieldCount - 1) myLine += reader[i].ToString() + ";";
                            else myLine += reader[i].ToString();
                            
                        }
                        catch { }
                    }
                    outText += myLine + "\n";
                }
                File.WriteAllText(ofName, outText);
                connection.Close();
                textBox1.Text = "~ " + ofName;

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
*/
            private void ButtonAgents_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
            agents = Papa.MkAgents();
            textBox2.Text = agents;
        }

        private void ButtonAgentsChoise_Click(object sender, RoutedEventArgs e)
        {
            var agentsSplit = agents.Split('\n');
            int choise = Convert.ToInt32(textBoxAgChoise.Text);
            var agentDirty = agentsSplit[choise];
            var agentDirtySplit = agentDirty.Split(' ');
            var agent = agentDirty.Split('_')[1];
            textBox1.Text = agent;

            Papa.partnerChoised = agent;
            //ClearMe();
            int x = 0;
            try
            {
                x = HrDep.MainHrDep();
                textBox1.Text = agent + " ~ " + Papa.infoSmall;
                textBox2.Text = Papa.infoBig;
            }
            catch { textBox2.Text = "Error"; }

            //textBox1.Text = textBoxAgChoise;
        }

        private void textBoxAgChoise_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
