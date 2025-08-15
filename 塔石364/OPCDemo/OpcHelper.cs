using GodSharp.Opc.Da;
using GodSharp.Opc.Da.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDemo
{
    public class OpcHelper
    {
        private static  OpcAutomationClient _client;

        private static bool _connected;
        /// <summary>
        /// 连接状态变更事件
        /// </summary>
        public static event Action<bool> OnConnectedChange;

        public static bool IsConnected
        {
            get => _connected;
            set
            {
                if (value != _connected)
                {
                    _connected = value;
                }
                OnConnectedChange?.Invoke(value);
            }

        }

        /// <summary>
        /// 得到服务名称列表
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static string[] GetServers(string host = null)
        {
            var serverList = new OpcServerList(host);
            serverList.GetServerList(out var serverNames, out _);
            return serverNames;

        }
        /// <summary>
        /// 连接OPC服务器
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static Task Connected(string ip, string progId,Action<DaClientOptions >optionsHandler=null )
        {
        
            return Task.Run(async() =>
            {
                if (_client != null)
                {
                  await   Disconnect();
                }
                _client = new OpcAutomationClient(options =>
                {
                    InitOpc(options,ip , progId);//初始化Options对象
                    optionsHandler?.Invoke(options);//将初始化好的Options对像交给用户，进行二次初始化（定制化）
                });
                IsConnected = _client.Connect();
            }); ;
        }
        public static void AddTags(string groupName, params Tag[] tags)
        { 
            if(_client.Groups.TryGetValue  (groupName,out var group))
            {
                group.Add(tags);
            
            }
        
        }
        public static void AddGroup(GroupData group) 
        {
            _client.Add(group);       
        }
        public static void AddGroup(string groupName, params Tag[] tags)//真心感觉这里有问题
        {
            _client.Add(groupName, tags);       
        }



        private static void InitOpc(DaClientOptions options,string ip,string progId)
        {
            options.Data = new ServerData()
            {
                Host = ip,
                ProgId = progId,
                Groups = new List<GroupData>()
            };


        }


        public static Task Disconnect()
        {
            return Task.Run(() =>
            {
                if (_client != null)
                {
                    //关闭服务
                    _client = null;
                    IsConnected = false;
                }

            });
        }
    }
}
