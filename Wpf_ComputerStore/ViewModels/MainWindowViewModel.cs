using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_ComputerStore.Models;

namespace Wpf_ComputerStore.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private List<ComputerDetail> computerDetailsList = new List<ComputerDetail>();
        public List<ComputerDetail> ComputerDetailsList
        {
            get { return computerDetailsList; }
            set
            {
                computerDetailsList = value;
                NotifyPropertyChanged("ComputerDetailsList");
            }
        }

        public MainWindowViewModel()
        {
            //using(DBContext db = new DBContext())
            //{
            //    Category c1 = new Category { Name = "RAM" };
            //    Category c2 = new Category { Name = "Motherboard" };
            //    Category c3 = new Category { Name = "CPU" };
            //    Category c4 = new Category { Name = "HardDrive" };
            //    Category c5 = new Category { Name = "SDD" };
            //    Category c6 = new Category { Name = "VideoCard" };
            //    Category c7 = new Category { Name = "PowerSupply" };

            //    db.Categories.Add(c1);
            //    db.Categories.Add(c2);
            //    db.Categories.Add(c3);
            //    db.Categories.Add(c4);
            //    db.Categories.Add(c5);
            //    db.Categories.Add(c6);
            //    db.Categories.Add(c7);

            //    PeripheralsType pt1 = new PeripheralsType { Name = "Keyboard" };
            //    PeripheralsType pt2 = new PeripheralsType { Name = "Printer" };
            //    PeripheralsType pt3 = new PeripheralsType { Name = "Mouse" };
            //    PeripheralsType pt4 = new PeripheralsType { Name = "Scanner" };
            //    PeripheralsType pt5 = new PeripheralsType { Name = "Webcam" };
            //    PeripheralsType pt6 = new PeripheralsType { Name = "Monitor" };


            //    Peripherals p1 = new Peripherals { Name = "Logitech K120", PeripheralsType = pt1, Quantity = 200, Price = 399, Description = "Клавіатура дротова \r\n Logitech K120 USB UKR OEM (920-002643)\r\n кількість кнопок клавіатури: 104 \r\n розкладка:  Eng / Ukr \r\n iнтерфейс: USB \r\n призначення :  для настiльного ПК" };
            //    Peripherals p2 = new Peripherals { Name = "Canon i-Sensys", PeripheralsType = pt2, Quantity = 120, Price = 12999, Description = "БФП Canon i-Sensys MF272dw \r\n Wi Fi, duplex (5621C013AA)\r\n Технологія друку -Лазерний друк \r\nКількість кольорів-1(чорний) \r\n Cпоживана потужність:Максимум: прибл. 1300 Вт\r\nУ режимі друку: прибл. 530 Вт\r\nУ режимі очікування: прибл. 4.8 Вт\r\nРежим сну: прибл. 1 Вт" };
            //    Peripherals p3 = new Peripherals { Name = "Logitech M185 ", PeripheralsType = pt3, Quantity = 300, Price = 599, Description = "Миша Logitech M185 Wireless Grey (910-002238/910-002235)\r\n Під'єднання:Бездротове" };
            //    Peripherals p4 = new Peripherals { Name = "Avision AD340GN ", PeripheralsType = pt4, Quantity = 50, Price = 20160, Description = "Протяжний сканер з мережевим інтерфейсом\r\n Avision AD340GN (000-1003-02G) \r\nОптична роздільна здатність: 600 dpi\r\nШвидкість сканування: 40 стор./хв.; 80 зображень/хв." };
            //    Peripherals p5 = new Peripherals { Name = "Trust Trino ", PeripheralsType = pt5, Quantity = 150, Price = 249, Description = "Веб-камера Trust Trino \r\nHD Video Webcam (TR18679)\r\n Сенсор:CMOS" };
            //    Peripherals p6 = new Peripherals { Name = "Acer Nitro ", PeripheralsType = pt6, Quantity = 200, Price = 5599, Description = "Монітор 23.8 Acer Nitro VG240YM3bmiipx \r\n(UM.QV0EE.304) FHD IPS / 180Hz / 1 ms / 8-Bit / sRGB 99% \r\n FreeSync Premium / Adaptive-Sync / G-Sync Сompatible / Динаміки 2w" };
            //    Peripherals p7 = new Peripherals { Name = "Combo BK-3001 ", PeripheralsType = pt1, Quantity = 280, Price = 559, Description = "Бездротова клавіатура Combo BK-3001 \r\n Wireless Bluetooth Silver \r\n російська розкладка клавіатури;\r\n кількість кнопок: 78; \r\nтип: мембранна; надтонка конструкція (4 мм); \r\n бездротове підключення на частоті 2.4 ГГц;\r\n живлення: 2 х ААА" };
            //    Peripherals p8 = new Peripherals { Name = "Canon PIXMA G3410", PeripheralsType = pt2, Quantity = 150, Price = 8999, Description = " БФП Canon PIXMA G3410 \r\n with Wi-Fi (2315C025/2315C009AA)\r\n Технологія друку- Струменевий друк\r\n Кількість кольорів-4" };
            //    Peripherals p9 = new Peripherals { Name = "RZTK S 430", PeripheralsType = pt3, Quantity = 400, Price = 200, Description = "Миша RZTK S 430 USB Black \r\n Під'єднання: Дротове" };
            //    Peripherals p10 = new Peripherals { Name = "Epson Perfection V39", PeripheralsType = pt4, Quantity = 100, Price = 4133, Description = "Сканер A4 Epson Perfection V39 (B11B268401)\r\n Роздільна здатність сканера: 4800 x 4800 dpi" };
            //    Peripherals p11 = new Peripherals { Name = "Asus Webcam", PeripheralsType = pt5, Quantity = 100, Price = 1899, Description = "Веб-камера Asus Webcam C3 Black (90YH0340-B2UA00)\r\n Сенсор:Full HD" };
            //    Peripherals p12 = new Peripherals { Name = "MSI Optix", PeripheralsType = pt6, Quantity = 120, Price = 1099, Description = "Монітор 27  MSI Optix G27CQ4 E2 -- QHD VA Curved 170Hz \r\n 8-Bit + FRC / sRGB 114% / Adaptive Sync / G-SYNC Compatible \r\n Freesync Premium / Console Mode 120Hz" };
            //    Peripherals p13 = new Peripherals { Name = "Asus TUF Gaming VG27AQ", PeripheralsType = pt6, Quantity = 30, Price = 11599, Description = "Монітор 27 Asus TUF Gaming VG27AQ  \r\n  (90LM0500-B03370) -- IPS 2K / 165 Гц  \r\n  8-Bit / 99% sRGB / G-Sync Сompatible  \r\n  Adaptive-Sync / HDR10" };
            //    Peripherals p14 = new Peripherals { Name = "Lenovo 29  L29w-30", PeripheralsType = pt6, Quantity = 60, Price = 7999, Description = "Монітор Lenovo 29  L29w-30 (66E5GAC3UA)   \r\n UltraWide FHD IPS / 90Гц / 8-Bit  \r\n  sRGB 99% / Adaptive-Sync  \r\n  AMD Radeon FreeSync / Speakers 3W" };



            //    db.Peripheralss.Add(p1);
            //    db.Peripheralss.Add(p2);
            //    db.Peripheralss.Add(p3);
            //    db.Peripheralss.Add(p4);
            //    db.Peripheralss.Add(p5);
            //    db.Peripheralss.Add(p6);
            //    db.Peripheralss.Add(p7);
            //    db.Peripheralss.Add(p8);
            //    db.Peripheralss.Add(p9);
            //    db.Peripheralss.Add(p10);
            //    db.Peripheralss.Add(p11);
            //    db.Peripheralss.Add(p12);
            //    db.Peripheralss.Add(p13);
            //    db.Peripheralss.Add(p14);


            //    ComputerDetail cd1 = new ComputerDetail { Name = "Intel Core i5", Category = c3, Quantity = 100, Price = 12899, Description = "Процесор Intel Core i5-14600KF\r\n 4.0GHz/24MB (BX8071514600KF) s1700 BOX" };
            //    ComputerDetail cd2 = new ComputerDetail { Name = "Asus PCI-Ex GeForce RTX 3060", Category = c6, Quantity = 40, Price = 13299, Description = "Відеокарта Asus PCI-Ex GeForce RTX 3060\r\n Dual OC V2 LHR 12GB GDDR6 (192bit) (1837/15000) \r\n(1 x HDMI, 3 x DisplayPort) (DUAL-RTX3060-O12G-V2)" };
            //    ComputerDetail cd3 = new ComputerDetail { Name = "Gigabyte B550 AORUS Elite V2", Category = c2, Quantity = 100, Price = 5399, Description = "Материнська плата Gigabyte B550 AORUS Elite V2 (sAM4, AMD B550, PCI-Ex16)" };
            //    ComputerDetail cd4 = new ComputerDetail { Name = "Western Digital Purple 4TB", Category = c4, Quantity = 80, Price = 4029, Description = "Жорсткий диск Western Digital Purple 4TB \r\n5400rpm 256MB WD43PURZ 3.5 SATA III" };
            //    ComputerDetail cd5 = new ComputerDetail { Name = "Toshiba P300 500GB", Category = c4, Quantity = 50, Price = 849, Description = " Жорсткий диск Toshiba P300 500GB \r\n7200rpm 64MB HDWD105UZSVA 3.5 SATA III" };
            //    ComputerDetail cd6 = new ComputerDetail { Name = "Kingston Fury DDR4-3200", Category = c1, Quantity = 70, Price = 1569, Description = "Оперативна пам'ять Kingston Fury DDR4-3200\r\n 16384 MB PC4-25600 (Kit of 2x8192)\r\n Beast Black (KF432C16BBK2/16)" };
            //    ComputerDetail cd7 = new ComputerDetail { Name = "DeepCool PF750 750W ", Category = c7, Quantity = 100, Price = 2299, Description = "Блок живлення DeepCool PF750 \r\n750W (R-PF750D-HA0B-EU)" };
            //    ComputerDetail cd8 = new ComputerDetail { Name = "System Power 10 750W", Category = c7, Quantity = 50, Price = 3349, Description = "Блок живлення System Power 10 750W (BN329)" };
            //    ComputerDetail cd9 = new ComputerDetail { Name = "SSD Western Digital", Category = c5, Quantity = 70, Price = 3495, Description = "SSD Western Digital PC SN740 1Tb\r\n M.2 2230 PCIE Gen4 x4 NVME \r\n(SDDPTQD-1T00) OEM" };
            //    ComputerDetail cd10 = new ComputerDetail { Name = "SAsus PCI-Ex Radeon RX 560", Category = c6, Quantity = 50, Price = 5209, Description = "Відеокарта Asus PCI-Ex Radeon RX 560 ROG Strix \r\n 4GB GDDR5 (128bit) (1199/6800)\r\n (HDMI, DVI-D) (ROG-STRIX-RX560-4G-V2-GAMING)" };
            //    ComputerDetail cd11 = new ComputerDetail { Name = "ASUS PCI-Ex GeForce RTX 4070", Category = c6, Quantity = 30, Price = 29379, Description = "Відеокарта ASUS PCI-Ex GeForce RTX 4070 \r\n Dual White OC Edition 12GB GDDR6X \r\n(192bit) (2550/21000) (1 x HDMI, 3 x DisplayPort) \r\n(DUAL-RTX4070-O12G-WHITE)" };
            //    ComputerDetail cd12 = new ComputerDetail { Name = "AMD Ryzen 7 5700X", Category = c3, Quantity = 50, Price = 7099, Description = "Процесор AMD Ryzen 7 5700X 3.4GHz/32MB \r\n(100-100000926WOF) sAM4 BOX" };
            //    ComputerDetail cd13 = new ComputerDetail { Name = "Intel Core i9-14900K", Category = c3, Quantity = 70, Price = 25699, Description = "Процесор Intel Core i9-14900K\r\n 4.4GHz/36MB (BX8071514900K) s1700 BOX" };
            //    ComputerDetail cd14 = new ComputerDetail { Name = "Kingston Fury SODIMM", Category = c1, Quantity = 70, Price = 2999, Description = "Оперативна пам'ять Kingston Fury SODIMM \r\nDDR4-3200 32768 MB PC4-25600 (Kit of 2x16384)\r\n Impact Black (KF432S20IBK2/32)" };


            //    db.ComputerDetails.Add(cd1);
            //    db.ComputerDetails.Add(cd2);
            //    db.ComputerDetails.Add(cd3);
            //    db.ComputerDetails.Add(cd4);
            //    db.ComputerDetails.Add(cd5);
            //    db.ComputerDetails.Add(cd6);
            //    db.ComputerDetails.Add(cd7);
            //    db.ComputerDetails.Add(cd8);
            //    db.ComputerDetails.Add(cd9);
            //    db.ComputerDetails.Add(cd10);
            //    db.ComputerDetails.Add(cd11);
            //    db.ComputerDetails.Add(cd12);
            //    db.ComputerDetails.Add(cd13);
            //    db.ComputerDetails.Add(cd14);

            //    ComputerType ct1 = new ComputerType { Name = "Desktop" };
            //    ComputerType ct2 = new ComputerType { Name = "Laptop" };
            //    db.ComputerTypes.Add(ct1);
            //    db.ComputerTypes.Add(ct2);

            //    Computer comp1 = new Computer { Name = "Tor AMD Ryzen", ComputerType = ct1, Quantity = 5 };
            //    Computer comp2 = new Computer { Name = "ARTLINE Business", ComputerType = ct1, Quantity = 5 };
            //    Computer comp3 = new Computer { Name = "Lenovo IdeaCentre ", ComputerType = ct1, Quantity = 5 };
            //    Computer comp4 = new Computer { Name = "ASUS TUF", ComputerType = ct2, Quantity = 10 };
            //    Computer comp5 = new Computer { Name = "Apple MacBook Air 13.6", ComputerType = ct2, Quantity = 10 };
            //    Computer comp6 = new Computer { Name = "ASUS Vivobook 15X OLED", ComputerType = ct2, Quantity = 8 };
            //    db.SaveChanges();
            //    comp1.ComputerDetails.Add(cd2);
            //    comp1.ComputerDetails.Add(cd1);
            //    comp1.ComputerDetails.Add(cd3);
            //    comp2.ComputerDetails.Add(cd4);
            //    comp2.ComputerDetails.Add(cd1);
            //    comp2.ComputerDetails.Add(cd2);
            //    comp2.ComputerDetails.Add(cd5);
            //    comp3.ComputerDetails.Add(cd1);
            //    comp3.ComputerDetails.Add(cd2);
            //    comp3.ComputerDetails.Add(cd9);
            //    comp4.ComputerDetails.Add(cd1);
            //    comp4.ComputerDetails.Add(cd8);
            //    comp4.ComputerDetails.Add(cd9);

            //   db.Computers.Add(comp1);
            //    db.Computers.Add(comp2);
            //    db.Computers.Add(comp3);
            //    db.Computers.Add(comp4);
            //    //Computers.Add(comp5);
            //    //Computers.Add(comp6);

            //    db.SaveChanges();
            //}
            getComputerDetails();
        }

        public void getComputerDetails()
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    ComputerDetailsList = db.ComputerDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
