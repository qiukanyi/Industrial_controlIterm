using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GodSharp.Opc.Da ;
using AntdUI;
using HmExtension.Commons.Extensions;
using System.IO.Ports;
using GodSharp.Opc.Da.Options;
using OPCDemo.Properties;
using System.Threading;
namespace OPCDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 如果sender是一个AntdUI.Button类型的btn
            if (sender is AntdUI.Button btn)
            {
                // 设置btn的Loading属性为true
                btn .Loading=true;
                // 创建一个OpcServerList类型的serverList
                OpcServerList serverList = new OpcServerList();
                // 调用serverList的GetServerList方法，获取serverNames，并将_作为参数传入
                serverList.GetServerList(out var serverNames, out _);//,out _就是说参数我不需要，所以用_代替
                // 清除serverCb的Items
                serverCb.Items.Clear();
                // 将serverNames添加到serverCb的Items中
                serverCb.Items.AddRange(serverNames);
                // 设置serverCb的SelectedIndex为0
                serverCb .Enabled = true;
                // 设置btn的Loading属性为false
                btn .Loading = false;

            }
        }

        private OpcAutomationClient client;
        private void button2_Click(object sender, EventArgs e)
        {
            client = new OpcAutomationClient(InitOpc);//参数传递有俩种方式，1委托2.原本就写好了
            client .Connect().FormatPatten ("连接状态；{}").Println();
            var browseNodeTree = client.BrowseNodeTree();
            foreach (var node in browseNodeTree)
            { 
                var treeItem = createTreeItem(node);
                tree1 .Items .Add(treeItem);
            }
            tree1 .ExpandAll ();//展开所有节点

        }
        private TreeItem createTreeItem(BrowseNode node)
        {
           // 创建一个新的TreeItem对象，将node.Name赋值给ti.Name，将node赋值给ti.Tag
            var ti = new TreeItem(node.Name)
            {
                Tag = node
            };
            // 如果node.Childs存在，则遍历node.Childs中的每个元素，将每个元素传入createTreeItem方法，并将返回值添加到ti.Sub中
            if (node.Childs?.Any()??false )
            {
                foreach (var child in node.Childs)
                {
                    ti.Sub.Add(createTreeItem(child));
                }
            }
            // 返回ti
            return ti;
        }
       
     





        private void InitOpc(DaClientOptions options)
        {
            // 设置服务器数据
            options.Data = CreateServerData();

            // 设置数据改变时的处理函数
            options.OnDataChangedHandler += dco =>
            {
                // 获取标签值
                var tagValue = dco.Data;
                // 如果选中的树项不为空，并且标签值为BrowseNode类型
                if (SelectedTreeItem!=null && SelectedTreeItem.Tag is BrowseNode node)
                {
                    // 如果标签值与BrowseNode类型的Full属性相等
                    if (tagValue.ItemName == node.Full)
                    {
                        // 更新标签值
                        UpdateTagValue(tagValue);
                    }
                }
            };
        }
        private ServerData CreateServerData()
        {
            var sd = new ServerData() {
                Host = IPTb.Text,
                ProgId = serverCb.SelectedValue?.ToString(),
            };
            sd .Groups=CreatesGroups();
            return sd;
        }

        /// <summary>
        /// 创建组
        /// </summary>
        /// <returns></returns>
        private List<GroupData> CreatesGroups()
        {
          var tagNames=  Resources.tags.Split('|');
            var tags = new List<GodSharp.Opc.Da.Tag>();

            for (int i = 0; i < tagNames.Length; i++)
            {
                tags.Add(new GodSharp.Opc.Da.Tag()
                {
                    ItemName = tagNames[i],
                    ClientHandle = i
                });
            }

            var list = new List<GroupData>
            {
                new GroupData()
                {
                    Name = "Default",
                    Tags = tags,    
                    IsSubscribed = true,
                    UpdateRate = 100,
                }
            };
            return list;
        }

        private TreeItem selsctTreeItem;


        public Action<TreeItem> OnSelectChangedTreeItem;
        public TreeItem SelectedTreeItem
        { 
        get => selsctTreeItem;
        set 
            {
                if (value != selsctTreeItem)
                { 
                    selsctTreeItem = value;
                    OnSelectChangedTreeItem?.Invoke(value);
                }
            
            }
        }


        private void tree1_SelectChanged(object sender, MouseEventArgs args, TreeItem item, Rectangle rect)
        {
            if(item.Tag is BrowseNode node  && node .IsLeaf )
            { 
                nodeNameCb .Text = node.Name;
                nodePathCb .Text = node.Full ;
                SelectedTreeItem = item;
            }
        }

        private void input1_TextChanged(object sender, EventArgs e)
        {

        }

        private string[] qualityNames = { "未知", "良好", "差" };


        private void button3_Click(object sender, EventArgs e)
        {
            //1.获得当前数中选择的节点
            var ti = SelectedTreeItem;
            if (ti.Tag is BrowseNode node)
            {
                //2.根据节点获得数据
                var  ar  =    client.Read("Default", node.Full);
                //3.将读取到的数据显示到界面
                var tagValue = ar.Result;
                UpdateTagValue(tagValue);
             
            }

        }
        private void UpdateTagValue(TagValue tagValue)
        {
            if (tagValue != null)
            {
                nodeValueDb.Text = tagValue.Value.ToString();
                qualityTb.Text = qualityNames[(int)tagValue.Quality];
                updateTimeCb.Text = $"{tagValue.Timestamp:yyyy-MM-dd HH:mm:ss}";
            }

        }
       
    }
}
