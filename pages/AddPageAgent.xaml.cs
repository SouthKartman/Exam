using System;
using System.Collections.Generic;
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

namespace GlazkiProgram.pages
{
    /// <summary>
    /// Логика взаимодействия для AddPageAgent.xaml
    /// </summary>
    public partial class AddPageAgent : Page
    {
        Agent agents = new Agent();
        public AddPageAgent()
        {
            InitializeComponent();

        }

        private void AddServiceBt_Click(object sender, RoutedEventArgs e)
        {
            agents.Title = TitleTB.Text;
            agents.AgentTypeID = int.Parse(AgentTypeTB.Text);
            agents.Address = AdressTB.Text;
            agents.INN = INNTB.Text;
            agents.KPP = KPPTB.Text;
            agents.DirectorName = DirectorTB.Text;
            agents.Phone = PhoneTB.Text;
            agents.Email = EmailTB.Text;
            agents.Logo = LogoTB.Text;
            agents.Priority = int.Parse(PriorityTB.Text);

            core.db.Agent.Add(agents);
            core.db.SaveChanges();
            NavigationService.GoBack();
            MessageBox.Show("Agent Add");
        }
    }
}
