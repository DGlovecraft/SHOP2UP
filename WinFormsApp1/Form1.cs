using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Security.Policy;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        item wateritem=new item();
        item teaitem = new item();
        item Noodleitem = new item();
        item Burgeritem = new item();
        discountitem Discountitem = new discountitem();
        public Form1()
        {

            InitializeComponent();
            //add data to object
            wateritem.name = "water";
            wateritem.price = 25;
            wateritem.quantity = 0;
            wateritem.check = water_cb.Checked;

            teaitem.name = "Tea";
            teaitem.price = 20;
            teaitem.quantity = 0;
            teaitem.check = Tea_check.Checked;

            Noodleitem.name = "Noodle";
            Noodleitem.price = 25;
            Noodleitem.quantity = 0;
            Noodleitem.check = Noodle_cb.Checked;

            Burgeritem.name = "Burger";
            Burgeritem.price = 20;
            Burgeritem.quantity = 0;
            Burgeritem.check = Burger_Check.Checked;

            Discountitem.namedis = "Tb_DisDrink";
            Discountitem.per = 0;
            Discountitem.checkdis = Discount_Drink.Checked;

            Discountitem.namedis = "Discount_Food";
            Discountitem.per = 0;
            Discountitem.checkdis = Discount_Food.Checked;

            Discountitem.namedis = "Discount_All";
            Discountitem.per= 0;
            Discountitem.checkdis = Discount_All.Checked;


            //display data
            waterP.Text = wateritem.price.ToString();
            waterP.ReadOnly = true;

            TeaPrice.Text = teaitem.price.ToString();
            TeaPrice.ReadOnly = true;

            NoodleP.Text = Noodleitem.price.ToString();
            NoodleP.ReadOnly = true;

            Burger_Price.Text = Burgeritem.price.ToString();
            Burger_Price.ReadOnly = true;

           


        }
        public double Item(TextBox item1, TextBox itemamount1, TextBox item2, TextBox itemamount2, CheckBox item_check1, CheckBox item_check2)
        {


            string inCofprice = item1.Text;
            string inamount = itemamount1.Text;
            string inTeaprice = item2.Text;
            string inTeaAmount = itemamount2.Text;

            double Cofprice = 0;
            double amount = 0;
            double teaAmount = 0;
            double teaprice = 0;

            try
            {
                if (item_check1.Checked)
                    Cofprice = double.Parse(inCofprice);
                amount = double.Parse(inamount);

            }
            catch (FormatException) { }
            try
            {
                if (item_check2.Checked)
                    teaprice = double.Parse(inTeaprice);
                teaAmount = double.Parse(inTeaAmount);
            }
            catch (FormatException)
            {

            }
            double sum1 = Cofprice * amount;
            double sum2 = teaprice * teaAmount;
            double sum = sum1 + sum2;
            return sum;
        }
        public double DiscountAll(double Drink, double Food)
        {
            double sum1 = 0;
            if (Discount_All.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = double.Parse(Tb_DisAll.Text);
                    double all = Drink + Food;
                    all = all - (all * discountvalue / 100);
                    sum1 += all;

                }
                catch (FormatException)
                {
                    double all = Drink + Food;
                    sum1 += all;
                }


            }
            return sum1;
        }
        public double DiscountDrink(double Drink)
        {
            if (Discount_Drink.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = double.Parse(Tb_DisDrink.Text);
                    Drink = Drink - (Drink * discountvalue / 100);

                }
                catch (FormatException)
                { Drink = Drink - (Drink * discountvalue / 100); }

            }
            return Drink;
        }
        public double DiscountFood(double Food)
        {
            if (Discount_Food.Checked)
            {
                double discountvalue = 0;
                try
                {
                    discountvalue = double.Parse(Tb_DisFood.Text);
                    Food = Food - (Food * discountvalue / 100);

                }
                catch (FormatException)
                {
                    Food = Food - (Food * discountvalue / 100);

                }
            }

            return Food;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (water_cb.Checked == false)
            {
                waterP.Enabled = false;
                waterQ.Enabled = false;
            }
            if (water_cb.Checked == true)
            {
                waterP.Enabled = true;
                waterQ.Enabled = true;
            }

        }

        private void CoffeePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Drink = Item(waterP, waterQ, TeaPrice, HowManyTea, water_cb, Tea_check);
            double Food = Item(NoodleP, NoodleQ, Burger_Price, Burger_Amount, Noodle_cb, Burger_Check);
            double sum1 = 0;
            if (Discount_All.Checked)
            {
                sum1 += DiscountAll(Drink, Food);

            }
            else if (Discount_Drink.Checked)
            {
                Drink = DiscountDrink(Drink);
                sum1 += Drink + Food;

            }

            else if (Discount_Food.Checked)
            {
                Food = DiscountFood(Food);
                sum1 += Food + Drink;



            }
            else
            {
                sum1 += Drink + Food;
            }
            Total.Text = sum1.ToString();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            double cash = 0;
            try
            {

                cash = double.Parse(Cash.Text);

            }
            catch (FormatException) { }

            try
            {
                total = double.Parse(Total.Text);
            }
            catch (FormatException) { }
            double change = cash - total;
            Change.Text = change.ToString();

            double OneT = 0;
            double FiveH = 0;
            double oneH = 0;
            double fifty = 0;
            double twenty = 0;
            double ten = 0;
            double five = 0;
            double one = 0;
            double fiftystang = 0;
            double twentyfivestang = 0;
            double tenstang = 0;
            double fivestang = 0;
            double onestang = 0;
            while (change >= 0.01)
            {
                if (change >= 1000)
                {
                    change -= 1000;
                    OneT++;
                }
               else if (change >= 500)
                {
                    change -= 500;
                    FiveH++;
                }
                else if (change >= 100)
                {
                    change -= 100;
                    oneH++;
                }
                else if (change >= 50)
                {
                    change -= 50;
                    fifty++;
                }
                else if (change >= 20)
                {
                    change -= 20;
                    twenty++;
                }
                else if (change >= 10)
                {
                    change -= 10;
                    ten++;
                }
                else if (change >= 5)
                {
                    change -= 5;
                    five++;
                }
                else if (change >= 1)
                {
                    change -= 1;
                    one++;
                }
                else if (change >= 0.50)
                {
                    change -= 0.50;
                    fiftystang++;
                }
                else if (change >= 0.25)
                {
                    change -= 0.25;
                    twentyfivestang++;
                }
                else if (change >= 0.10)
                {
                    change -= 0.10;
                    tenstang++;
                }
                else if (change >= 0.05)
                {
                    change -= 0.05;
                    fivestang++;
             
                }
                else if (change >= 0.01)
                {
                    change -= 0.01;
                    onestang++;
                }
            }
            OneThousand.Text = OneT.ToString();
            FiveHundred.Text = FiveH.ToString();
            OneHundred.Text = oneH.ToString();
            Fifty.Text = fifty.ToString();
            Twenty.Text = twenty.ToString();
            Ten.Text = ten.ToString();
            Five.Text = five.ToString();
            One.Text = one.ToString();
            FiftyStang.Text = fiftystang.ToString();
            TwentyFiveStang.Text = twentyfivestang.ToString();
            TenStang.Text = tenstang.ToString();
            FiveStang.Text = fivestang.ToString();
            OneStang.Text = onestang.ToString();


        }

        private void Tea_check_CheckedChanged(object sender, EventArgs e)
        {
            if (Tea_check.Checked == true)
            {
                TeaPrice.Enabled = true;
                HowManyTea.Enabled = true;
            }
            if (Tea_check.Checked == false)
            {
                TeaPrice.Enabled = false;
                HowManyTea.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_Drink.Checked)
            {
                Discount_All.Checked = false;
                Discount_Food.Checked = false;
                Tb_DisDrink.Enabled = true;
            }
            else
            {
                Tb_DisDrink.Enabled = false;
            }
        }

        private void Discount_Food_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_Food.Checked)
            {
                Discount_All.Checked = false;
                Discount_Drink.Checked = false;
                Tb_DisFood.Enabled = true;
            }
            else
            {
                Tb_DisFood.Enabled = false;
            }
        }

        private void Discount_All_CheckedChanged(object sender, EventArgs e)
        {
            if (Discount_All.Checked)
            {
                Discount_Drink.Checked = false;
                Discount_Food.Checked = false;
                Discount_All.Checked = true;
                Tb_DisAll.Enabled = true;
            }
            else
            {
                Tb_DisAll.Enabled = false;
            }

        }


        private void Pizza_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Noodle_cb.Checked)
            {
                NoodleP.Enabled = true;
                NoodleQ.Enabled = true;
            }
            else
            {
                NoodleP.Enabled = false;
                NoodleQ.Enabled = false;
            }

        }

        private void Burger_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Burger_Check.Checked == true)
            {
                Burger_Price.Enabled = true;
                Burger_Amount.Enabled = true;
            }
            else
            {
                Burger_Price.Enabled = false;
                Burger_Amount.Enabled = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

