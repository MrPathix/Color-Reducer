﻿using PD.BitmapWrapper;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Color_Clusterizer
{
    public partial class ColorClusterizer
    {
        private void InitializeContextMenus()
        {
            ContextMenuStrip contextKmeans = new ContextMenuStrip();
            ContextMenuStrip contextUncertainty = new ContextMenuStrip();

            ToolStripMenuItem kmeansSave = new ToolStripMenuItem("Save to file...");
            ToolStripMenuItem uncertaintySave = new ToolStripMenuItem("Save to file...");
            
            kmeansSave.Click += ContextMenuSaveImageHandler;
            kmeansSave.Name = "kmeans";

            uncertaintySave.Click += ContextMenuSaveImageHandler;
            uncertaintySave.Name = "uncertainty";

            contextKmeans.Items.Add(kmeansSave);
            contextUncertainty.Items.Add(uncertaintySave);

            kmeansPictureBox.ContextMenuStrip = contextKmeans;
            uncertaintyPictureBox.ContextMenuStrip = contextUncertainty;
        }

        private void ContextMenuSaveImageHandler(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            // propagation of uncertainty not implemented yet
            BitmapWrapper wrapper = item.Name.Equals("kmeans") ? Controller.KmeansClusteredImage : null;

            if (wrapper is null)
            {
                MessageBox.Show("No image to save.");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Image File(*.jpeg)|*.jpeg;"
            };
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                wrapper.Bitmap.Save(dialog.FileName, ImageFormat.Jpeg);
            }
            else
            {
                MessageBox.Show("[ERROR] Couldn't save to file.");
            }

            dialog.Dispose();
        }
    }
}