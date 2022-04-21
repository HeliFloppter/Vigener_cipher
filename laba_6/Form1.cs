namespace laba_6
{
    public partial class Main : Form
    {
        Vigener_cipher cipher = new Vigener_cipher();
        public Main()
        {
            InitializeComponent();
        }


        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            
            textBoxEncrypted.Text = cipher.encrypt(textBoxToEncrypt.Text, textBoxKeyword.Text);
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            
            textBoxEncrypted.Text = cipher.decrypt(textBoxToEncrypt.Text, textBoxKeyword.Text);
        }
    }


    public interface Iface
    {
        string encrypt(string text, string keyword);
        string decrypt(string text, string keyword);
    }

    public class Vigener_cipher: Iface
    {

        
        char[] characters = new char[] { 'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', '¨', 'Æ', 'Ç', 'È',
                                                'É', 'Ê', 'Ë', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ñ',
                                                'Ò', 'Ó', 'Ô', 'Õ', 'Ö', '×', 'Ø', 'Ù', 'Ü', 'Û', 'Ú',
                                                'Ý', 'Þ', 'ß', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0', ',', '!', '?', '.', ':', ';', '-'};

    

        public string encrypt(string text, string keyword)
        {
            text = text.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in text)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % characters.Length;

                result += characters[c];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        public string decrypt(string text, string keyword)
        {
            text = text.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in text)
            {
                int p = (Array.IndexOf(characters, symbol) + characters.Length -
                    Array.IndexOf(characters, keyword[keyword_index])) % characters.Length;

                result += characters[p];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }
    }
}