using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Desktop.Model
{

    public interface IApplicationCommands {
        CompositeCommand LoadCommand { get; }
    }
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand LoadCommand { get; } = new CompositeCommand();
    }
}
