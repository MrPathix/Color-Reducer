﻿using Color_Reducer.FilterMatrices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Color_Reducer
{
    public partial class ColorReducer
    {
        private FilterMatrix Filter { get; set; }
        private Dictionary<string, FilterMatrix> Filters { get; set; } = new();

        private void InitializeFiltersDictionary()
        {
            Filters.Add("floydSteinbergRadioButton", new FloydAndSteinbergFilterMatrix());
            Filters.Add("burkesRadioButton", new BurkesFilterMatrix());
            Filters.Add("stuckyRadioButton", new StuckyFilterMatrix());

            Filter = Filters["floydSteinbergRadioButton"];
        }

        private void FilterMatrixRadioButtonsHandler(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (!rb.Checked) return;

            Filter = Filters[rb.Name];
        }
    }
}
