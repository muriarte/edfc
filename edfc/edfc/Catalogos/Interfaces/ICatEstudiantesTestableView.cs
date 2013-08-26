using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inotech.Edfc.Catalogos
{
    public interface ICatEstudiantesTestableView
    {
        EEditionMode EditionMode { get; }
        IList<string> ValidationErrors { get; }
        Dictionary<string, string> ItemFields { get; }
        void ClickOnNewButton();
        void ClickOnSaveButton();
        void ClickOnCloseButton();
        void Validate();
    }
}
