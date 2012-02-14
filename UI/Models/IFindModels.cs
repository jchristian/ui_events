using System.Collections.Generic;

namespace UI.Models
{
    public interface IFindModels
    {
        IEnumerable<ModelType> FindAll<ModelType>();

        void Register<ModelType>(ModelType model);
        void UnRegister(object model);
    }
}