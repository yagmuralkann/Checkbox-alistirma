/* Bu projede amaç kullanıcı ekrana en fazla 10 tane checkbox ekleyebilmesidir. 10 tane ekledikten sonra ekleme yapmak isterse uyarı mesajı alır.
Eklediği checkboxlardan ise maksimum 3 tane seçim yapabilir. 
Visual Studio 2026 kullanılmıştır. C# form uygulamasıyla çalışır.*/

namespace gorselprogramlamaodev
{
    public partial class Form1 : Form
    {
        int checkboxSayisi = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        
           
        {
            // maksimum 10 checkbox
            if (checkboxSayisi >= 10)
            {
                MessageBox.Show("Daha fazla ekleyemezsiniz");

                label1.Text = "Hakkınız Bitti";

                button1.Enabled = false;

                return;
            }

            // textbox boş mu
            if (textBox1.Text == "")
            {
                MessageBox.Show("Bir değer giriniz");
                return;
            }

            // yeni checkbox oluştur
            CheckBox cb = new CheckBox();

            // checkbox yazısı
            cb.Text = textBox1.Text;

            // konum
            cb.Left = 10;
            cb.Top = checkboxSayisi * 30;

            // boyut otomatik
            cb.AutoSize = true;

            // seçim kontrolü
            cb.CheckedChanged += KontrolEt;

            // panel içine ekle
           panel1.Controls.Add(cb);

            // sayaç arttır
            checkboxSayisi++;

            // kalan hak
            label1.Text = "Kalan Hakkınız: " + (10 - checkboxSayisi);

            // textbox temizle
            textBox1.Clear();
        }

        // maksimum 3 seçim kontrolü
        private void KontrolEt(object sender, EventArgs e)
        {
            CheckBox tiklanan = (CheckBox)sender;

            int seciliAdet = 0;

            // paneldeki tüm checkboxları say
            foreach (Control item in panel1.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox cb = (CheckBox)item;

                    if (cb.Checked)
                    {
                        seciliAdet++;
                    }
                }
            }

            // 3'ten fazla seçim varsa
            if (seciliAdet > 3)
            {
                MessageBox.Show("En fazla 3 seçim yapabilirsiniz");

                tiklanan.Checked = false;
            }
        }

        // Seçimleri Gönder butonu



        private void button2_Click_1(object sender, EventArgs e)
        {
            {
                listBox1.Items.Clear();

                bool varMi = false;

                foreach (Control item in panel1.Controls)
                {
                    if (item is CheckBox cb && cb.Checked)
                    {
                        listBox1.Items.Add(cb.Text);
                        varMi = true;
                    }
                }

                if (!varMi)
                {
                    MessageBox.Show("Hiç seçim yapılmadı");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
