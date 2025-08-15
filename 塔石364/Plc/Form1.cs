using HmExtension.Commons.Extensions;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Plc
{
    public partial class Form1 : Form
    {
        //创建一个plc的客户端
        private S7.Net.Plc plc;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建plc
            plc =new S7.Net.Plc (
                CpuType.S71500 ,
                input1 .Text ,
                (int)inputNumber1 .Value ,
                (short )inputNumber2 .Value, 
                (short )inputNumber3 .Value);
            //连接
            plc.Open ();
            
        }


        //读取数据
        private void button2_Click(object sender, EventArgs e)
        {
            //var value = plc.Read(input2 .Text );//第一种
            //var value =plc .Read(DataType.DataBlock, 1 , 4,VarType.Real ,1);//局限性很大，第二种
           // var value = plc.ReadBytes(DataType.DataBlock, 1, 4, 4);//第三种


            //好处：所有的数据类型都可以转换成为byte数组
            //byte可以转换为其他数据类型


            //input3.Tag = value;
            //var selectedValue = (TypeConvert)select1.SelectedValue;
            //input3.Text = $"{selectedValue.Convert(0, value)}";
            DataType.TryParse<DataType>(select2.SelectedValue.ToString(), out var dataType);


            //通过变量名来读取：
            //1byte 如果变量是bool类型，那么返回参数实际类型为bool类型
            //2byte 如果变量是short,ushort类型，那么返回参数的实际类型为ushort类型
            //4byte 如果变量是int,uint,float类型，那么返回参数的实际类型为uint类型
            //8byte 如果变量是double,long,ulong类型，那么返回参数的实际类型为ulong类型

            //第二种读取方式：通过直接读取byte[]的方式，然后通过转换器来进行转换为对应的类型
            
            var value=plc .ReadBytes(
                dataType, 
                (int )inputNumber4 .Value, 
                (int )inputNumber5 .Value, 
                (int )inputNumber6 .Value
                 
                );
            input3.Tag = value;
            input3.Text = $"{((TypeConvert)select1.SelectedValue).Convert((int)inputNumber7.Value, value)}";


           
        }

        private void select1_SelectedIndexChanged(object sender, int value)
        {
            if (input3.Tag == null) return;
            input3.Text = $"{((TypeConvert)select1.SelectedValue).Convert((int)inputNumber7.Value,(byte[] )input3.Tag)}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var types = new List<object>
            {
                 new TypeConvert ((bytes ,bit)=>bytes.Reverse().ToUShort ()){Name = "Ushort"},
                 new TypeConvert((bytes ,bit)=>bytes.Reverse().ToShort ()){Name = "Short"},
                 new TypeConvert((bytes ,bit)=>bytes.Reverse().ToUInt ()){Name = "Uint"},
                 new TypeConvert((bytes ,bit)=>bytes.Reverse().ToInt ()){Name = "Int"},
                 new TypeConvert((bytes ,bit)=>bytes.Reverse().ToFloat ()){Name = "Float"},
                 new TypeConvert ((bytes ,bit)=>bytes.Reverse().ToDouble ()){Name = "Double"},
                 new TypeConvert((bytes ,bit)=>
                 {           
                    return bytes[0] >>bit  == 1;
                 }){Name = "Bool"},
                 
            };
            select1 .Items.AddRange(types );
            select1.SelectedIndex = 0;
            //初始化存储区
            select2 .Items.AddRange(Enum .GetNames(typeof(DataType)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // plc.WriteBytes();
            plc.Write("DB1.DBD6", 68.8F);
        }
    }

    public class TypeConvert(Func<byte[], int,object > convert)
    {
        private Func<byte[], int, object> _convert=convert ;

        public  string Name { get; set; }

        public object Convert(int bit ,params byte[] bytes)
        { 
            return _convert(bytes,bit);        
        }
        public override string ToString()
        { 
        return   Name;
        }



    }
}
