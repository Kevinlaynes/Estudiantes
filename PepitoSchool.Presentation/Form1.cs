using PepitoSchool.AppCore.Interface;
using PepitoSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchool.Presentation
{
    public partial class Form1 : Form
    {
        private IEstudiantesService estudiantesService;

        public Form1(IEstudiantesService estudiantesServices)
        {
            this.estudiantesService = estudiantesService;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = new Estudiante()
            {
                Nombres = "Juan",
                Apellidos = "Lopez",
                Carnet = "3456789015",
                Phone = "45678912",
                Direccion = "RRRRRRRRRRR",
                Correo = "4ferge",
                Matematica = 4,
                Contabilidad = 2,
                Programacion = 78,
                Estadistica=56,
           
               
               
            };

            estudiantesService.Create(estudiante);
            LoadDataGridView();
        }


        private void LoadDataGridView()
        {
            dataGridView1.DataSource = estudiantesService.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
