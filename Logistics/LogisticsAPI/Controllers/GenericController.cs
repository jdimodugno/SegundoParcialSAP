using LogisticsBusiness.Components;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsAPI.Controllers
{
    public abstract class GenericController<T, Z> : ControllerBase
        where T : class
        where Z : BaseComponent<T>
    {
        protected readonly BaseComponent<T> _component;

        public GenericController(BaseComponent<T> component)
        {
            _component = component;
        }
    }
}
