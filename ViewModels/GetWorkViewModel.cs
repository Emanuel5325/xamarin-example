using MauiExample.Database;

namespace MauiExample.ViewModels
{
    public class GetWorkViewModel : BaseViewModel
    {
        public GetWorkViewModel(MauiExampleDatabase database) : base(database) => this.Title = "Datos de Obra";
    }
}
