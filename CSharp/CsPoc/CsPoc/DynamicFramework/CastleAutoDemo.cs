using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class CastleAutoDemo
    {
        public static void Execute()
        {
            //建立容器

            var container = new WindsorContainer();

            container.Install(
                new ControllersInstaller(),
               new RepositoriesInstaller());


            //获取组件
            var log = container.Resolve<ILog>();
            var fr = container.Resolve<ILogFormatter>();
            


            //使用组件
            log.Write("First Castle IOC Demo");

            Console.ReadLine();
        }
    }

    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Component.For<ILogFormatter>().ImplementedBy<PlanFormatter>());

            //container.Register(Classes.FromThisAssembly()
            //                    .Where(Component.IsInSameNamespaceAs<TextFileLog>())
            //                    .WithService.DefaultInterfaces().LifestyleTransient());


        }
    }

    public class ControllersInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ILog>().ImplementedBy<TextFileLog>());
            //container.Register(Classes.FromThisAssembly()
            //                    .Where(Component.IsInSameNamespaceAs<ILogFormatter>())
            //                    .WithService.DefaultInterfaces()
            //                    .LifestyleTransient());
        }
    }

    public interface ILog
    {

        void Write(string MsgStr);

    }

    public interface ILogFormatter
    {
        string Format(string MsgStr);
    }

    public class TextFormatter : ILogFormatter
    {
        public TextFormatter()
        {

        }

        public string Format(string MsgStr)
        {
            return "[" + MsgStr + "]";
        }
    }

    public class PlanFormatter : ILogFormatter
    {
        public PlanFormatter()
        {

        }

        public string Format(string MsgStr)
        {
            return "{" + MsgStr + "}";
        }
    }

    public class TextFileLog : ILog
    {
        private string _target;

        private ILogFormatter _format;

        public TextFileLog(ILogFormatter format)
        {
            //this._target = "abc";

            this._format = format;
        }

        //public TextFileLog(string target, ILogFormatter format)
        //{
        //    this._target = target;

        //    this._format = format;
        //}

        public void Write(string MsgStr)
        {
            string _MsgStr = _format.Format(MsgStr);

            //_MsgStr += _target;


            //Output Message

            Console.WriteLine("Output " + _MsgStr);
        }
    }
}
