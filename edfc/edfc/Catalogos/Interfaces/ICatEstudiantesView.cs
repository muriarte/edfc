﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inotech.Edfc.Catalogos
{
    public interface ICatEstudiantesView
    {
        void Initialize(Catalogos.CatEstudiantesPresenter presenter);
        void SetEditionMode(EEditionMode editionMode);
        void DisplayItemFields(System.Collections.Generic.Dictionary<string, string> fields);
        void ShowMessageBox(string message, string title);
        void ShowMessageBox(string message, string title, eMessageBoxButtons buttons);
    }
}
