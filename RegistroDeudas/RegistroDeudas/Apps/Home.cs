using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RegistroDeudas.Apps
{
    public class Home : ContentPage
    {
        Dictionary<string, int> NombreCategoria = new Dictionary<string, int>
        {
            { "Compras", 1 }, { "Ventas", 2 }
        };

        public Home()
        {
            // Sistema de Grilla
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
            // Declarar Elementos Superiores
            var image = new Image
            {
                HeightRequest = 126,
                WidthRequest = 126,
                Margin = new Thickness(10, 20, 10, 10),
                HorizontalOptions = LayoutOptions.Center,
                Source = "money.png"
            };
            // Botones Tipo Acción
            Button btn_compra = new Button {Text = "Compras" };
            Button btn_venta = new Button { Text = "Ventas" };
            Button btn_transferencia = new Button { Text = "Transferencias" };

            var stack_botones = new StackLayout();

            stack_botones.Children.Add(btn_compra);
            stack_botones.Children.Add(btn_venta);
            stack_botones.Children.Add(btn_transferencia);

            grid.Children.Add(image, 0, 0);
            grid.Children.Add(stack_botones, 1, 0);

            var margen = new Thickness(50, 0, 50, 0);
            Label lbl_descripcion = new Label { Text = "Descripción:", Margin = margen };
            Entry ent_descripcion = new Entry { Margin = margen };
            Label lbl_monto = new Label { Text = "Monto:", Margin = margen };
            Entry ent_monto = new Entry { Margin = margen, Keyboard = Keyboard.Numeric };
            Picker picker = new Picker { Title = "Categoria", Margin = margen };
            foreach (string colorName in NombreCategoria.Keys)
            {
                picker.Items.Add(colorName);
            }
            // Picker por Defecto
            picker.SelectedIndex = 0;

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    //color por defecto
                }
                else
                {
                    // seleccionado picker.Items[picker.SelectedIndex];nameToColor[colorName];
                }
            };
            var contentView = new ContentView
            {
                Content = new StackLayout
                {
                    Children = {
                         grid,
                         lbl_descripcion,
                         ent_descripcion,
                         lbl_monto,
                         ent_monto,
                         picker
                    }
                },
                ControlTemplate = formato_template
            };
            Content = contentView;
        }
        class FormatoTemplate : Grid
        {
            public FormatoTemplate()
            {
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.05, GridUnitType.Star) });
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.50, GridUnitType.Star) });
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.05, GridUnitType.Star) });
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.05, GridUnitType.Star) });
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.95, GridUnitType.Star) });

                var topBoxView = new BoxView { Color = Color.Orange };
                Children.Add(topBoxView, 0, 0);
                Grid.SetColumnSpan(topBoxView, 2);
                var topLabel = new Label
                {
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 25,
                    FontAttributes = FontAttributes.Italic
                };
                topLabel.SetBinding(Label.TextProperty, new TemplateBinding("Parent.HeaderText"));
                Children.Add(topLabel, 1, 0);

                var contentPresenter = new ContentPresenter();
                Children.Add(contentPresenter, 0, 1);
                Grid.SetColumnSpan(contentPresenter, 2);


                var bottomLabel = new Label
                {
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center
                };
                bottomLabel.SetBinding(Label.TextProperty, new TemplateBinding("Parent.FooterText"));
                Children.Add(bottomLabel, 1, 2);
            }
        }
        ControlTemplate formato_template = new ControlTemplate(typeof(FormatoTemplate));
        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create("HeaderText", typeof(string), typeof(Home), "Bienvenido a Registro Deudas");

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
        }
    }
}