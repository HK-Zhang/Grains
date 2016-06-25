using Abp.Web.Mvc.Views;

namespace JunDemo.Web.Views
{
    public abstract class JunDemoWebViewPageBase : JunDemoWebViewPageBase<dynamic>
    {

    }

    public abstract class JunDemoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected JunDemoWebViewPageBase()
        {
            LocalizationSourceName = JunDemoConsts.LocalizationSourceName;
        }
    }
}