using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace MysqlDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IDbConnection conn = new MySqlConnection(connestr))
            {
                conn.Open();
                for (int i = 115389; i < 2000002; i++)
                {
                    Exec(i,conn);
                    Console.WriteLine($"插入成功第{i + 1}");
                }
            }
            Console.ReadLine();
        }

        private static readonly string connestr = "server=39.105.168.143;port=3306;database=test;uid=root;password=angelIN2019;Allow User Variables=True;Charset=utf8mb4;";

        public static void Exec(int i, IDbConnection conn)
        {


            //
            var command = conn.CreateCommand();
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("INSERT INTO `wobshiporder` VALUES");
            stringBuilder.Append($"('{Guid.NewGuid()}', NULL, 'P0000081', '北京传越', '2019-07-31 09:26:17.314260', '9268bfba-1727-41b9-87f3-5221cf6d7b94', " +
                $"'管理员', NULL, '', NULL, 300, 'Y1907310000118', 'fe752f40-6013-4740-b2b2-6cf2cb898a9c', 0, '', " +
                $"'2019-08-03 00:00:00.000000', NULL, 'C0000011', '顺丰', '00000000-0000-0000-0000-000000000000', NULL, '2019-08-01 00:00:00.000000'," +
                $" 1, NULL, 'j/VVUget97WSNg8SdBnsIme3Us/e8errSK1KBz28zoSdWsd/Y+ZXbpgHjB+itB2vdiKj7x7eOWPTlDlU6lkwFyYjLECtjcyLIuexehibdsRbxTl5DjR9lW7dtpjc9jth2hQid2xeCqU4ThdBnKLTSA=='," +
                $" '北京市', '大兴区', 'YabKQlMeweeYQz89AOo7Cg==', '010EF', 'QqbEgBdrgNLB6yiw9Yha8Q==', '102600', '北京市', NULL, NULL, 'S00819073100000{i + 1}', 400, 3, 'rhTou6bR8/AC16VEXT4426HCFhAgMuh+/HW9qvJtWwKmxSOLtSSk6BWuwbRFKWbd', " +
                $"'北京市', '顺义区', 'VkkO+UzuRhfGFZtDBrHBZg==', '个人', 'B9DHuI2yhYvYhuP6hBELvg==', '北京市', 'O1301201907270202312442', '顺丰ELog-50OMS订单', '39ecc0db-44de-514f-d953-60767a4a9b5a', " +
                $"'39ee4d4b-1237-0ede-2e57-7974dcdad516', 100.000000000000000000000000000000, 0.000000000000000000000000000000, 0.000000000000000000000000000000, 0.000000000000000000000000000000, " +
                $"100.000000000000000000000000000000, 100.000000000000000000000000000000, 0.000000000000000000000000000000, 0.000000000000000000000000000000, '2019-07-31 09:54:41.404831', '3bca2985-113b-409a-a781-bf4267025a54'," +
                $" '张志伟-北京DC订单管理员-全日制', 'OEC_SFOMS1907310001223', '39ef57e9-67fe-8b8b-6ec0-932d8b147882', '39eef5f5-c6b7-e639-22e4-3a75adea6274', NULL, 0.000000000000000000000000000000, '', ''," +
                $" '000000430100300685,热敏运单|105mm*76mm|单联|无卷芯/90枚/卷,', 0.000000000000000000000000000000, NULL, 'PX19072700001249', NULL, 1, '', '', 0, '0001-01-01 00:00:00.000000', NULL, '39ee70a4-ca54-d1d1-b195-1b6325cd9925', '') ;");
            command.CommandText = stringBuilder.ToString();
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();


        }
    }
}
