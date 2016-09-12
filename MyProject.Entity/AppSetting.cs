using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MyProject.Entity
{
    public class AppSetting
    {
        #region 内部属性及方法
        private static readonly Lazy<AppSetting> AppSettingLazy = new Lazy<AppSetting>(() => new AppSetting());
        private readonly Configuration _config;
        private AppSetting()
        {
            _config = GetConfiguration();
        }
        //获取当前AppConfig
        private Configuration GetConfiguration()
        {
            string environmentDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (environmentDirectoryPath != null)
            {
                string configPath = Path.Combine(environmentDirectoryPath, "MyProject.WPF.exe");
                //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap(configPath);
                Configuration config = ConfigurationManager.OpenExeConfiguration(configPath);
            
                return config;
            }
            return null;
        }
        #endregion
        /// <summary>
        /// 当前实例
        /// </summary>
        public static AppSetting Instance
        {
            get { return AppSettingLazy.Value; }
        }
        /// <summary>
        /// 判断存在Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _config.AppSettings.Settings.AllKeys.Any(i => i == key);
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            var aaa = _config.ConnectionStrings;
            var bbb = aaa.ConnectionStrings[key].ToString();
            return bbb;
            //return _config.AppSettings.Settings[key].Value;
        }
    }
}
