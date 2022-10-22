using System;
using System.Collections.Generic;   //List 사용

namespace _07._14.NestedClass
{
    class configuration
    {
        List<ItemValue> listConfig = new List<ItemValue>();
        public void SetConfig(string item, string value)
        {
            ItemValue iv = new ItemValue();
            iv.SetValue(this, item, value);
        }
        public string GetConfig(string item)
        {
            foreach (ItemValue iv in listConfig)
            {
                if(iv.GetItem() == item)
                {
                    return iv.GetValue();
                }
            }
            return "";
        }
        private class ItemValue     //configuration안에 삽입된 중첩클래스
        {
            private string item;
            private string value;
            public void SetValue(configuration config, string item, string value)   //Key, Value처럼 해당하는 값을 세팅
            {
                this.item = item;
                this.value = value;

                bool found = false;
                for (int i = 0; i < config.listConfig.Count; i++)   //listConfig.Count갯수가 1이상일때
                {
                    if (config.listConfig[i].item == item)      //listConfig배열에 들어간 item과 매개변수 item이 동일할 경우
                    {
                        config.listConfig[i] = this;            //listConfig배열에 this의 값을 넣는다
                        found = true;
                        break;
                    }
                }
                if (found == false)
                    config.listConfig.Add(this); //this는 configuration->List<ItemValue> 값이다.
            }
            public string GetItem()
            { return item; }
            public string GetValue()
            { return value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            configuration config = new configuration();
            config.SetConfig("Version", "V 5.0");
            config.SetConfig("Size", "655,324 KB");
            Console.WriteLine(config.GetConfig("Version"));
            Console.WriteLine(config.GetConfig("Size"));

            config.SetConfig("Version", "V 5.0.1");
            Console.WriteLine(config.GetConfig("Version"));
        }
    }
}
