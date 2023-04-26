using ProductManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManager
{
    public partial class Form1 : Form
    {
        private readonly IProductServices _services;
        
        private async void LoadBrands()
        {
            var brands = await _services.GetBrands();
            List<dynamic> dynList = new List<dynamic>(brands);
            listBox1.DataSource = dynList;
            listBox1.DisplayMember = "ProductBrandName";
            listBox1.ValueMember = "Id";
        }
        private async void LoadCategories()
        {
            var categories = await _services.GetCategories();
            List<dynamic> dynList = new List<dynamic>(categories);
            listBox2.DataSource = dynList;
            listBox2.ValueMember = "Id";
            listBox2.DisplayMember = "ProductCategoryName";
        }
        private async void Add()
        {
            Guid categoryId = new Guid ((listBox2.SelectedValue).ToString());
            var branId = new Guid((listBox1.SelectedValue).ToString());
            await _services.CreateProduct(textBox1.Text, listBox2.Text, categoryId , listBox1.Text, branId);
        }
        
        public Form1(IProductServices services)
        {
            _services = services;
            LoadBrands();
            LoadCategories();
            LoadProducts();
            InitializeComponent();
        }
        private async void LoadProducts()
        {
            var product = await _services.GetProducts();
            List<dynamic> dynList = new List<dynamic>(product);
            dataGridView1.DataSource = dynList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add();
            LoadProducts();
        }
    }
}
