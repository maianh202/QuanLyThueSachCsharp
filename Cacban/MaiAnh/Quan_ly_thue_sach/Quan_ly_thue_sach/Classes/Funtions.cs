using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quan_ly_thue_sach.Classes
{
    class Funtions
    {
        public static SqlConnection Conn;
        public static string connString;

        public static void KetNoi()
        {
            connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\Desktop\Slidemonhoc\CSLT2\GitHub\CSharp-Programing\SQL\Quan_ly_thue_sach\Quan_ly_thue_sach\Database\QL_ThueSach.mdf;Integrated Security=True;Connect Timeout=30";
            Conn = new SqlConnection(connString);
            Conn.Open();
        }

        public static void NgatKetNoi()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }

        public static DataTable GetDataToTable(string SQL)
        {
            SqlDataAdapter sda = new SqlDataAdapter(SQL, Conn);
            DataTable tbl = new DataTable();
            sda.Fill(tbl);
            return tbl;
        }

        /// <summary>
        /// Trả về True nếu mã xuất hiện trong bảng, và False nếu không có
        /// </summary>
        public static bool Checkkey(string SQL) // Viet truoc
        {

            SqlDataAdapter sda = new SqlDataAdapter(SQL, Conn);
            DataTable tbl = new DataTable();
            sda.Fill(tbl);
            if (tbl.Rows.Count > 0)
                return true;
            else
                return false;
        }


        // Co the dung SqlDataAdapter
        public static void RunSQL(string SQL)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = SQL;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }


        public static void RunDelSQL(string SQL)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = SQL;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception del)
            {
                MessageBox.Show("Du lieu dang dung boi chuong" +
                    " trinh khac, khong the xoa" + " " + del.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        /// <summary>
        /// Phương thức để dùng bảng khác cho ComboBox
        /// </summary>
        public static void FillCombo(string SQL, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter sda = new SqlDataAdapter(SQL, Conn);
            DataTable tbl = new DataTable();
            sda.Fill(tbl);
            cbo.DataSource = tbl;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }

        /// <summary>
        /// Dùng đối tượng SqlDataReader, có hai phương thức là 
        /// Read() - Dùng để kiểm tra dòng tiếp theo có tồn tại - true 
        /// và GetValue(Chỉ số) - Dùng để lấy cột muốn lấy dữ liệu
        /// </summary>     
        public static string GetFieldValues(string sql)
        {
            string value = "";
            SqlCommand sc = new SqlCommand(sql, Conn);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                value = sdr.GetValue(0).ToString();
            }
            sdr.Close();
            return value;
        }

        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }

        public static bool isDate(string d)
        {
            string[] parts = d.Split('/');
            int date, month, year;
            date = (Convert.ToInt32(parts[0]));
            month = (Convert.ToInt32(parts[1]));
            year = (Convert.ToInt32(parts[2]));
            if (date >= 1 && date <= 31 &&
                month >= 1 && month <= 12 &&
                year >= 1900)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Với CreateKey là một hàm toàn cục được viết trong Class Functions, 
        /// có tác dụng sinh khóa tự động cho Mã hóa đơn bán.
        /// </summary>
        public static string CreateKey(string tiento)
        {
            string key = tiento;

            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            string d = string.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            // 15/12/2021 -> {"15", "12", "2021"} -> 15122021
            key += d;

            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');

            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];

            // Xoa Space & AM hoac PM
            partsTime[2] = partsTime[2].Remove(2, 3);

            string t;
            t = String.Format("{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            // 5:12:02 AM -> {"5", "12", "02 AM"} -> 051202
            key = key + t;

            return key;
        }

        /// <summary>
        /// Với ConvertTimeTo24 là một hàm toàn cục được viết trong Class Functions,
        /// có tác dụng chuyển đổi giờ từ dạng PM sang dạng 24h.
        /// </summary>
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            if (Convert.ToInt32(hour) == 12)
            {
                h = 0.ToString();
            }
            else
            {
                for (int i = 1; i < 12; i++)
                {
                    if (Convert.ToInt32(hour) == i)
                    {
                        h = (12 + i).ToString();
                        break;
                    }
                }
            }
            return h;
        }


        /// <summary>
        /// Với ChuyenSoSangChu là một hàm toàn cục được viết trong Class Functions,
        /// có tác dụng đọc từ dạng số sang dạng chữ.
        /// </summary>
        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            // Xoa cac dau "," neu co
            sNumber = sNumber.Replace(",", "");
            mNumText = "khong;mot;hai;ba;bon;nam;sau;bay;tam;chin".Split(';');
            mLen = sNumber.Length - 1; // Vi thu tu di tu 0
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];

                if (mLen == i) // Chu so cuoi khong xet tiep
                    break;

                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp = mTemp + " ty";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 6:
                        mTemp = mTemp + " trieu";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 3:
                        mTemp = mTemp + " nghin";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2:
                                mTemp = mTemp + " tram";
                                break;
                            case 1:
                                mTemp = mTemp + " muoi";
                                break;
                        }
                        break;
                }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            //Loại bỏ trường hợp 00x
            mTemp = mTemp.Replace("không mươi ", "linh ");
            //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }
    }
}
