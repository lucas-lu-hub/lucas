using Abp.Web.Mvc.Views;

namespace TestProject.Web.Views
{
    public abstract class TestProjectWebViewPageBase : TestProjectWebViewPageBase<dynamic>
    {

    }

    public abstract class TestProjectWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TestProjectWebViewPageBase()
        {
            LocalizationSourceName = TestProjectConsts.LocalizationSourceName;
        }
    }
}