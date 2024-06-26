﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Windows.Media;

namespace Wpf_ComputerStore.Models
{
    public class DBContext : DbContext
    {
        static DbContextOptions<DBContext> _options;
        //static private string connectionString;
        static DBContext()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }

        public DBContext()
            : base(_options)
        {
            if (Database.EnsureCreated())
            {
                Category c1 = new Category { Name = "RAM" };
                Category c2 = new Category { Name = "Motherboard" };
                Category c3 = new Category { Name = "CPU" };
                Category c4 = new Category { Name = "HardDrive" };
                Category c5 = new Category { Name = "SDD" };
                Category c6 = new Category { Name = "VideoCard" };
                Category c7 = new Category { Name = "PowerSupply" };

                Categories.Add(c1);
                Categories.Add(c2);
                Categories.Add(c3);
                Categories.Add(c4);
                Categories.Add(c5);
                Categories.Add(c6);
                Categories.Add(c7);

                PeripheralsType pt1 = new PeripheralsType { Name = "Keyboard" };
                PeripheralsType pt2 = new PeripheralsType { Name = "Printer" };
                PeripheralsType pt3 = new PeripheralsType { Name = "Mouse" };
                PeripheralsType pt4 = new PeripheralsType { Name = "Scanner" };
                PeripheralsType pt5 = new PeripheralsType { Name = "Webcam" };
                PeripheralsType pt6 = new PeripheralsType { Name = "Monitor" };


                Peripherals p1 = new Peripherals { Name = "Logitech K120", PeripheralsType = pt1, Quantity = 200, Price = 399, Description = "Клавіатура дротова \r\n Logitech K120 USB UKR OEM (920-002643)\r\n кількість кнопок клавіатури: 104 \r\n розкладка:  Eng / Ukr \r\n iнтерфейс: USB \r\n призначення :  для настiльного ПК" };
                Peripherals p2 = new Peripherals { Name = "Canon i-Sensys", PeripheralsType = pt2, Quantity = 120, Price = 12999, Description = "БФП Canon i-Sensys MF272dw \r\n Wi Fi, duplex (5621C013AA)\r\n Технологія друку -Лазерний друк \r\nКількість кольорів-1(чорний) \r\n Cпоживана потужність:Максимум: прибл. 1300 Вт\r\nУ режимі друку: прибл. 530 Вт\r\nУ режимі очікування: прибл. 4.8 Вт\r\nРежим сну: прибл. 1 Вт" };
                Peripherals p3 = new Peripherals { Name = "Logitech M185 ", PeripheralsType = pt3, Quantity = 300, Price = 599, Description = "Миша Logitech M185 Wireless Grey (910-002238/910-002235)\r\n Під'єднання:Бездротове" };
                Peripherals p4 = new Peripherals { Name = "Avision AD340GN ", PeripheralsType = pt4, Quantity = 50, Price = 20160, Description = "Протяжний сканер з мережевим інтерфейсом\r\n Avision AD340GN (000-1003-02G) \r\nОптична роздільна здатність: 600 dpi\r\nШвидкість сканування: 40 стор./хв.; 80 зображень/хв." };
                Peripherals p5 = new Peripherals { Name = "Trust Trino ", PeripheralsType = pt5, Quantity = 150, Price = 249, Description = "Веб-камера Trust Trino \r\nHD Video Webcam (TR18679)\r\n Сенсор:CMOS" };
                Peripherals p6 = new Peripherals { Name = "Acer Nitro ", PeripheralsType = pt6, Quantity = 200, Price = 5599, Description = "Монітор 23.8 Acer Nitro VG240YM3bmiipx \r\n(UM.QV0EE.304) FHD IPS / 180Hz / 1 ms / 8-Bit / sRGB 99% \r\n FreeSync Premium / Adaptive-Sync / G-Sync Сompatible / Динаміки 2w" };
                Peripherals p7 = new Peripherals { Name = "Combo BK-3001 ", PeripheralsType = pt1, Quantity = 280, Price = 559, Description = "Бездротова клавіатура Combo BK-3001 \r\n Wireless Bluetooth Silver \r\n російська розкладка клавіатури;\r\n кількість кнопок: 78; \r\nтип: мембранна; надтонка конструкція (4 мм); \r\n бездротове підключення на частоті 2.4 ГГц;\r\n живлення: 2 х ААА" };
                Peripherals p8 = new Peripherals { Name = "Canon PIXMA G3410", PeripheralsType = pt2, Quantity = 150, Price = 8999, Description = " БФП Canon PIXMA G3410 \r\n with Wi-Fi (2315C025/2315C009AA)\r\n Технологія друку- Струменевий друк\r\n Кількість кольорів-4" };
                Peripherals p9 = new Peripherals { Name = "RZTK S 430", PeripheralsType = pt3, Quantity = 400, Price = 200, Description = "Миша RZTK S 430 USB Black \r\n Під'єднання: Дротове" };
                Peripherals p10 = new Peripherals { Name = "Epson Perfection V39", PeripheralsType = pt4, Quantity = 100, Price = 4133, Description = "Сканер A4 Epson Perfection V39 (B11B268401)\r\n Роздільна здатність сканера: 4800 x 4800 dpi" };
                Peripherals p11 = new Peripherals { Name = "Asus Webcam", PeripheralsType = pt5, Quantity = 100, Price = 1899, Description = "Веб-камера Asus Webcam C3 Black (90YH0340-B2UA00)\r\n Сенсор:Full HD" };
                Peripherals p12 = new Peripherals { Name = "MSI Optix", PeripheralsType = pt6, Quantity = 120, Price = 1099, Description = "Монітор 27  MSI Optix G27CQ4 E2 -- QHD VA Curved 170Hz \r\n 8-Bit + FRC / sRGB 114% / Adaptive Sync / G-SYNC Compatible \r\n Freesync Premium / Console Mode 120Hz" };
                Peripherals p13 = new Peripherals { Name = "Asus TUF Gaming VG27AQ", PeripheralsType = pt6, Quantity = 30, Price = 11599, Description = "Монітор 27 Asus TUF Gaming VG27AQ  \r\n  (90LM0500-B03370) -- IPS 2K / 165 Гц  \r\n  8-Bit / 99% sRGB / G-Sync Сompatible  \r\n  Adaptive-Sync / HDR10" };
                Peripherals p14 = new Peripherals { Name = "Lenovo 29  L29w-30", PeripheralsType = pt6, Quantity = 60, Price = 7999, Description = "Монітор Lenovo 29  L29w-30 (66E5GAC3UA)   \r\n UltraWide FHD IPS / 90Гц / 8-Bit  \r\n  sRGB 99% / Adaptive-Sync  \r\n  AMD Radeon FreeSync / Speakers 3W" };



                Peripheralss.Add(p1);
                Peripheralss.Add(p2);
                Peripheralss.Add(p3);
                Peripheralss.Add(p4);
                Peripheralss.Add(p5);
                Peripheralss.Add(p6);
                Peripheralss.Add(p7);
                Peripheralss.Add(p8);
                Peripheralss.Add(p9);
                Peripheralss.Add(p10);
                Peripheralss.Add(p11);
                Peripheralss.Add(p12);
                Peripheralss.Add(p13);
                Peripheralss.Add(p14);


                ComputerDetail cd1_CPU = new ComputerDetail { Name = "Intel Core i5", Category = c3, Quantity = 100, Price = 12899, Description = "Процесор Intel Core i5-14600KF\r\n 4.0GHz/24MB (BX8071514600KF) s1700 BOX" };
                ComputerDetail cd2_CPU = new ComputerDetail { Name = "AMD Ryzen 7 5700X", Category = c3, Quantity = 150, Price = 7099, Description = "Процесор AMD Ryzen 7 5700X 3.4GHz/32MB \r\n (100-100000926WOF) sAM4 BOX" };
                ComputerDetail cd3_CPU = new ComputerDetail { Name = "Intel Core i9-14900K", Category = c3, Quantity = 70, Price = 25699, Description = "Процесор Intel Core i9-14900K\r\n 4.4GHz/36MB (BX8071514900K) s1700 BOX" };
                ComputerDetail cd4_CPU = new ComputerDetail { Name = "Intel Core i9-13900", Category = c3, Quantity = 60, Price = 23759, Description = "Процесор Intel Core i9-13900 \r\n 2.0GHz/36MB (BX8071513900) s1700 BOX" };
                ComputerDetail cd5_CPU = new ComputerDetail { Name = "AMD Ryzen 7 7800X3D", Category = c3, Quantity = 70, Price = 15899, Description = "Процесор AMD Ryzen 7 7800X3D \r\n 4.2GHz/96MB (100-100000910WOF) sAM5 BOX" };
                ComputerDetail cd6_CPU = new ComputerDetail { Name = "AMD Ryzen 5 5600", Category = c3, Quantity = 50, Price = 6159, Description = "Процесор AMD Ryzen 5 5600 3.5GHz/32MB \r\n (100-100000927BOX) sAM4 BOX" };
                ComputerDetail cd7_CPU = new ComputerDetail { Name = "AMD Ryzen 5 7600X", Category = c3, Quantity = 75, Price = 9199, Description = "Процесор AMD Ryzen 5 7600X 4.7GHz/32MB \r\n (100-100000593WOF) sAM5 BOX" };
                ComputerDetail cd8_CPU = new ComputerDetail { Name = "Intel Core i5-10400F", Category = c3, Quantity = 85, Price = 6859, Description = "Процесор Intel Core i5-10400F \r\n 2.9GHz/12MB \r\n (BX8070110400F) s1200 BOX" };
                ComputerDetail cd9_CPU = new ComputerDetail { Name = "AMD Ryzen 9 7900X3D", Category = c3, Quantity = 75, Price = 19889, Description = "Процесор AMD Ryzen 9 7900X3D \r\n4.4GHz/128MB (100-100000909WOF) sAM5 BOX" };
                ComputerDetail cd10_CPU = new ComputerDetail { Name = "Intel Core i5-13400", Category = c3, Quantity = 50, Price = 10199, Description = "Процесор Intel Core i5-13400 \r\n 2.5GHz/20MB (BX8071513400) s1700 BOX" };
                ComputerDetail cd11_CPU = new ComputerDetail { Name = "Intel Core i5-12500", Category = c3, Quantity = 70, Price = 9999, Description = "Процесор Intel Core i5-12500 \r\n 3.0GHz/18MB (BX8071512500) s1700 BOX" };
                ComputerDetail cd12_CPU = new ComputerDetail { Name = "Intel Pentium Gold G6405", Category = c3, Quantity = 30, Price = 4448, Description = "Процесор Intel Pentium Gold G6405 \r\n 4.1GHz/4MB (BX80701G6405) s1200 BOX" };
                ComputerDetail cd13_CPU = new ComputerDetail { Name = "Intel Core i7-13700", Category = c3, Quantity = 80, Price = 16799, Description = "Процесор Intel Core i7-13700  \r\n 2.1GHz/30MB (BX8071513700) s1700 BOX" };
                ComputerDetail cd14_CPU = new ComputerDetail { Name = "AMD Ryzen 3 4100", Category = c3, Quantity = 80, Price = 2499, Description = "Процесор AMD Ryzen 3 4100 \r\n 3.8GHz/4MB (100-100000510BOX) sAM4 BOX" };


                ComputerDetail cd1_Motherboard = new ComputerDetail { Name = "Gigabyte B550 AORUS Elite V2", Category = c2, Quantity = 100, Price = 5399, Description = "Материнська плата Gigabyte B550 AORUS Elite V2 \r\n (sAM4, AMD B550, PCI-Ex16)" };
                ComputerDetail cd2_Motherboard = new ComputerDetail { Name = "Asus TUF Gaming B450-Plus II", Category = c2, Quantity = 100, Price = 3854, Description = "Материнська плата Asus TUF Gaming B450-Plus II \r\n  (sAM4, AMD B450, PCI-Ex16)" };
                ComputerDetail cd3_Motherboard = new ComputerDetail { Name = "Asus Prime H510M-A", Category = c2, Quantity = 100, Price = 2999, Description = "Материнська плата Asus Prime H510M-A \r\n  (s1200, Intel H510, PCI-Ex16)" };
                ComputerDetail cd4_Motherboard = new ComputerDetail { Name = "MSI MPG Z790 CARBON WIFI", Category = c2, Quantity = 100, Price = 15499, Description = "Материнська плата MSI MPG Z790 CARBON WIFI \r\n  (s1700, Intel Z790, PCI-Ex16)" };
                ComputerDetail cd5_Motherboard = new ComputerDetail { Name = "Gigabyte Z790 Aorus Elite AX ", Category = c2, Quantity = 100, Price = 12799, Description = " Материнська плата Gigabyte Z790 Aorus Elite AX \r\n (s1700, Intel Z790, PCI - Ex16) \r\n + SSD диск Goodram PX500 Gen.2 512GB M.2 2280 PCIe 3.0 x4 NVMe 3D NAND TLC" };
                ComputerDetail cd6_Motherboard = new ComputerDetail { Name = "Asus Prime B450M-A II", Category = c2, Quantity = 100, Price = 2933, Description = "Материнська плата Gigabyte B550 AORUS Elite V2  \r\n (sAM4, AMD B550, PCI-Ex16)" };
                ComputerDetail cd7_Motherboard = new ComputerDetail { Name = "Asus ROG STRIX Z790-F", Category = c2, Quantity = 100, Price = 18999, Description = "Материнська плата Asus Prime B450M-A II \r\n (sAM4, AMD B450, PCI-Ex16)" };
                ComputerDetail cd8_Motherboard = new ComputerDetail { Name = "Gigabyte B550 AORUS ELITE AX V2", Category = c2, Quantity = 100, Price = 6299, Description = "Материнська плата Gigabyte B550 AORUS ELITE AX V2 \r\n (sAM4, AMD B550, PCI-Ex16)" };
                ComputerDetail cd9_Motherboard = new ComputerDetail { Name = "MSI MAG B550 Tomahawk", Category = c2, Quantity = 100, Price = 6736, Description = "Материнська плата MSI MAG B550 Tomahawk \r\n (sAM4, AMD B550, PCI-Ex16)" };
                ComputerDetail cd10_Motherboard = new ComputerDetail { Name = "Asus ROG Maximus Z790 Dark Hero", Category = c2, Quantity = 100, Price = 29899, Description = "Материнська плата Asus ROG Maximus Z790 Dark Hero \r\n (s1700, Intel Z790, PCI-Ex16)" };
                ComputerDetail cd11_Motherboard = new ComputerDetail { Name = "Asus ROG STRIX Z790-E ", Category = c2, Quantity = 100, Price = 19499, Description = "Материнська плата Asus ROG STRIX Z790-E Gaming Wi-Fi \r\n (s1700, Intel Z790, PCI-Ex16)" };
                ComputerDetail cd12_Motherboard = new ComputerDetail { Name = "Gigabyte B560M H", Category = c2, Quantity = 100, Price = 3299, Description = "Материнська плата Gigabyte B560M H \r\n (s1200, Intel B560, PCI-Ex16)" };
                ComputerDetail cd13_Motherboard = new ComputerDetail { Name = "Asus ROG STRIX Z790-A ", Category = c2, Quantity = 100, Price = 17999, Description = "Материнська плата Asus ROG STRIX Z790-A GAMING WIFI II \r\n (s1700, Intel Z790, PCI-Ex16)" };
                ComputerDetail cd14_Motherboard = new ComputerDetail { Name = "Gigabyte Z790 Aero G", Category = c2, Quantity = 100, Price = 13559, Description = "Материнська плата Gigabyte Z790 Aero G \r\n (s1700, Intel Z790, PCI-Ex16) \r\n + SSD диск Gigabyte Gen3 2500E 500GB M.2 NVMe PCIe 3.0 x4 3D NAND (QLC)" };


                ComputerDetail cd1_VC = new ComputerDetail { Name = "Asus PCI-Ex GeForce RTX 3060", Category = c6, Quantity = 40, Price = 13299, Description = "Відеокарта Asus PCI-Ex GeForce RTX 3060\r\n Dual OC V2 LHR 12GB GDDR6 (192bit) (1837/15000) \r\n(1 x HDMI, 3 x DisplayPort) (DUAL-RTX3060-O12G-V2)" };
                ComputerDetail cd2_VC = new ComputerDetail { Name = "SAsus PCI-Ex Radeon RX 560", Category = c6, Quantity = 50, Price = 5209, Description = "Відеокарта Asus PCI-Ex Radeon RX 560 ROG Strix \r\n 4GB GDDR5 (128bit) (1199/6800)\r\n (HDMI, DVI-D) (ROG-STRIX-RX560-4G-V2-GAMING)" };
                ComputerDetail cd3_VC = new ComputerDetail { Name = "ASUS PCI-Ex GeForce RTX 4070", Category = c6, Quantity = 30, Price = 29379, Description = "Відеокарта ASUS PCI-Ex GeForce RTX 4070 \r\n Dual White OC Edition 12GB GDDR6X \r\n(192bit) (2550/21000) (1 x HDMI, 3 x DisplayPort) \r\n(DUAL-RTX4070-O12G-WHITE)" };
                ComputerDetail cd4_VC = new ComputerDetail { Name = "MSI PCI-Ex GeForce RTX 4060", Category = c6, Quantity = 40, Price = 15199, Description = "Відеокарта MSI PCI-Ex GeForce RTX 4060 Gaming X \r\n 8GB GDDR6 (128bit) (2610/17000)\r\n (HDMI, 3 x DisplayPort) (RTX 4060 GAMING X 8G)" };
                ComputerDetail cd5_VC = new ComputerDetail { Name = "Asus PCI-Ex Radeon RX 6750 XT Dual", Category = c6, Quantity = 50, Price = 16999, Description = "Відеокарта Asus PCI-Ex Radeon RX 6750 XT Dual \r\n OC 12GB GDDR6 (192bit) (2512/18000)\r\n (HDMI, 3 x DisplayPort) (DUAL-RX6750XT-O12G)" };
                ComputerDetail cd6_VC = new ComputerDetail { Name = "XFX PCI-Ex Radeon RX 6800", Category = c6, Quantity = 30, Price = 18709, Description = "XFX PCI-Ex Radeon RX 6800 Speedster SWFT 319 \r\n 16GB GDDR6 (256bit) (1700/16000)\r\n (HDMI, 3 x DisplayPort) (RX-68XLAQFD9)" };
                ComputerDetail cd7_VC = new ComputerDetail { Name = "Gigabyte PCI-Ex GeForce RTX 4070 Ti Aero", Category = c6, Quantity = 40, Price = 38499, Description = "Відеокарта Gigabyte PCI-Ex GeForce RTX 4070  \r\n Ti Aero OC V2 12GB GDDR6X  \r\n (192bit) (2640/21000) (HDMI, 3 x DisplayPort)  \r\n (GV-N407TAERO OCV2-12GD)" };
                ComputerDetail cd8_VC = new ComputerDetail { Name = "XFX Radeon RX 580 ", Category = c6, Quantity = 50, Price = 3340, Description = "Вiдеокарта XFX Radeon RX 580 (2048sp) 8GB GDDR5  \r\n (256bit) (1286/7000)  \r\n (DVI, HDMI, 3 x DisplayPort) (RX-580-2048SP) Б/В" };
                ComputerDetail cd9_VC = new ComputerDetail { Name = "SAPPHIRE Radeon RX 470", Category = c6, Quantity = 30, Price = 2940, Description = "Відеокарта SAPPHIRE Radeon RX 470 4GB NITRO  \r\n (1236/7000) with DVI Б/В" };
                ComputerDetail cd10_VC = new ComputerDetail { Name = "Gainward GeForce GTX 1660 ", Category = c6, Quantity = 40, Price = 7940, Description = "Вiдеокарта Gainward GeForce GTX 1660 Ti Ghost \r\n OC 6GB GDDR6 (192bit) (1815/12000)\r\n (HDMI, DisplayPort, DVI-D) (426018336-4436)" };
                ComputerDetail cd11_VC = new ComputerDetail { Name = "Sapphire Radeon RX580 (2048sp)", Category = c6, Quantity = 50, Price = 5450, Description = "Відеокарта Sapphire Radeon RX580 \r\n (2048sp) 8Gb 256bit DDR5 DVI HDMI DPort OEM" };
                ComputerDetail cd12_VC = new ComputerDetail { Name = "ASUS PCI-Ex GeForce RTX 4070 Ti ROG Strix ", Category = c6, Quantity = 30, Price = 41599, Description = "Відеокарта ASUS PCI-Ex GeForce RTX 4070 Ti ROG Strix  \r\n 12GB GDDR6X (192bit) (2640/21000) (2 x HDMI, 3 x DisplayPort)  \r\n (ROG-STRIX-RTX4070TI-12G-GAMING)" };
                ComputerDetail cd13_VC = new ComputerDetail { Name = "SAPPHIRE Radeon RX 470 ", Category = c6, Quantity = 40, Price = 3940, Description = "Відеокарта SAPPHIRE Radeon RX 470 4GB NITRO \r\n(1236/7000) with DVI Б/В" };
                ComputerDetail cd14_VC = new ComputerDetail { Name = "ASUS PCI-Ex GeForce RTX 4080 TUF Gaming", Category = c6, Quantity = 50, Price = 57309, Description = "Відеокарта ASUS PCI-Ex GeForce RTX 4080 TUF Gaming \r\n OC Edition 16GB GDDR6X (256bit) (2625/22400)\r\n  (2 x HDMI, 3 x DisplayPort) (TUF-RTX4080-O16G-GAMING)" };

                ComputerDetail cd1_RAM = new ComputerDetail { Name = "Kingston Fury SODIMM", Category = c1, Quantity = 70, Price = 2999, Description = "Оперативна пам'ять Kingston Fury SODIMM \r\nDDR4-3200 32768 MB PC4-25600 (Kit of 2x16384)\r\n Impact Black (KF432S20IBK2/32)" };
                ComputerDetail cd2_RAM = new ComputerDetail { Name = "Kingston Fury DDR4-3200", Category = c1, Quantity = 70, Price = 1569, Description = "Оперативна пам'ять Kingston Fury DDR4-3200\r\n 16384 MB PC4-25600 (Kit of 2x8192)\r\n Beast Black (KF432C16BBK2/16)" };
                ComputerDetail cd3_RAM = new ComputerDetail { Name = "Kingston Fury DDR4-3600", Category = c1, Quantity = 70, Price = 3199, Description = "Оперативна пам'ять Kingston Fury DDR4-3600 32768 MB \r\nPC4-28800 (Kit of 2x16384)\r\n Beast Black (KF436C18BBK2/32)" };
                ComputerDetail cd4_RAM = new ComputerDetail { Name = "Goodram DDR4-3200", Category = c1, Quantity = 70, Price = 1429, Description = "Оперативна пам'ять Goodram DDR4-3200 16384 MB \r\n PC4-25600 (Kit of 2x8192)\r\n IRDM X (IR-X3200D464L16SA/16GDC)" };
                ComputerDetail cd5_RAM = new ComputerDetail { Name = "G.Skill DDR3-1600", Category = c1, Quantity = 70, Price = 612, Description = "Оперативна пам'ять G.Skill DDR3-1600 8192MB \r\n PC3-12800 (F3-1600C11S-8GNT)" };
                ComputerDetail cd6_RAM = new ComputerDetail { Name = "Crucial SODIMM DDR4-3200", Category = c1, Quantity = 70, Price = 777, Description = "Оперативна пам'ять Crucial SODIMM DDR4-3200 8192 MB \r\n PC4-25600 (CT8G4SFRA32A))" };
                ComputerDetail cd7_RAM = new ComputerDetail { Name = "G.Skill DDR5-6400", Category = c1, Quantity = 70, Price = 14999, Description = "Оперативна пам'ять G.Skill DDR5-6400 98304MB PC5-51200 \r\n (Kit of 2x49152MB) Trident Z5 RGB Black \r\n(F5-6400J3239F48GX2-TZ5RK)" };
                ComputerDetail cd8_RAM = new ComputerDetail { Name = "Kingston Fury DDR4-2666", Category = c1, Quantity = 70, Price = 3129, Description = "Оперативна пам'ять Kingston Fury DDR4-2666 32768MB PC4-21300 \r\n (Kit of 2x16384) Beast Black (KF426C16BB1K2/32)" };
                ComputerDetail cd9_RAM = new ComputerDetail { Name = "ATRIA DDR3 - 1600", Category = c1, Quantity = 70, Price = 379, Description = "Оперативна пам'ять ATRIA DDR3-1600 8192MB \r\n PC3-12800 (UAT31600CL11K1/8)" };
                ComputerDetail cd10_RAM = new ComputerDetail { Name = "Goodram DDR3-1333 ", Category = c1, Quantity = 70, Price = 660, Description = "Оперативна пам'ять Goodram DDR3-1333 8192MB \r\n PC3-10600 (GR1333D364L9/8G)" };
                ComputerDetail cd11_RAM = new ComputerDetail { Name = "Kingston FURY DDR5-6400", Category = c1, Quantity = 70, Price = 18745, Description = "Оперативна пам'ять Kingston FURY DDR5-6400 98304MB \r\n PC5-51200 (Kit of 2x49152) Renegade RGB 2Rx8 Black \r\n (KF564C32RSAK2-96)" };
                ComputerDetail cd12_RAM = new ComputerDetail { Name = "Kingston Fury DDR4-2666", Category = c1, Quantity = 70, Price = 1535, Description = "Оперативна пам'ять Kingston Fury DDR4-2666 16384MB  \r\n PC4-21300 Beast Black (KF426C16BB1/16)" };
                ComputerDetail cd13_RAM = new ComputerDetail { Name = "Kingston FURY DDR5-6000", Category = c1, Quantity = 70, Price = 5799, Description = "Оперативна пам'ять Kingston FURY DDR5-6000 32768MB PC5-48000  \r\n (Kit of 2x16384) Beast RGB AM5 Black (KF560C36BBEAK2-32)" };
                ComputerDetail cd14_RAM = new ComputerDetail { Name = "ATRIA DDR4-3200", Category = c1, Quantity = 70, Price = 2999, Description = "Оперативна пам'ять ATRIA DDR4-3200 16384MB \r\n PC4-25600 (Kit of 2x8192) Fly Blue (UAT43200CL18BLK2/16)" };



                ComputerDetail cd1_HD = new ComputerDetail { Name = "Western Digital Purple 4TB", Category = c4, Quantity = 80, Price = 4029, Description = "Жорсткий диск Western Digital Purple 4TB \r\n5400rpm 256MB WD43PURZ 3.5 SATA III" };
                ComputerDetail cd2_HD = new ComputerDetail { Name = "Toshiba P300 500GB", Category = c4, Quantity = 50, Price = 849, Description = " Жорсткий диск Toshiba P300 500GB \r\n7200rpm 64MB HDWD105UZSVA 3.5 SATA III" };
                ComputerDetail cd3_HD = new ComputerDetail { Name = "Seagate Basic 2TB ", Category = c4, Quantity = 80, Price = 2699, Description = "Жорсткий диск Seagate Basic 2TB \r\n STJL2000400 2.5 USB 3.0 External Gray" };
                ComputerDetail cd4_HD = new ComputerDetail { Name = "Verbatim Store n Go 1TB", Category = c4, Quantity = 50, Price = 1999, Description = " Жорсткий диск Verbatim Store n Go 1TB 53023 2.5 \r\n USB 3.0 External Blister Black" };
                ComputerDetail cd5_HD = new ComputerDetail { Name = "Transcend StoreJet 25M3S 1TB", Category = c4, Quantity = 89, Price = 2849, Description = " Жорсткий диск Transcend StoreJet 25M3S 1TB  \r\n TS1TSJ25M3S 2.5 \r\n USB 3.1 Gen 1 External Iron Gray" };
                ComputerDetail cd6_HD = new ComputerDetail { Name = "Western Digital Ultrastar DC HC550 18TB", Category = c4, Quantity = 57, Price = 15849, Description = " Жорсткий диск Western Digital Ultrastar DC HC550 18TB \r\n 7200rpm 512MB WUH721818ALE6L4_0F38459 3.5\r\n SATA III" };
                ComputerDetail cd7_HD = new ComputerDetail { Name = "Toshiba Canvio Basics 4TB", Category = c4, Quantity = 83, Price = 4239, Description = "Жорсткий диск Toshiba Canvio Basics 4TB HDTB540EK3CA 2.5\r\n USB 3.2 External Black" };
                ComputerDetail cd8_HD = new ComputerDetail { Name = "Western Digital Red Pro NAS 18 TB", Category = c4, Quantity = 60, Price = 15819, Description = " Жорсткий диск Western Digital Red Pro \r\n NAS 18 TB 7200 rpm 512 MB WD181KFGX 3.5\r\n SATA III" };
                ComputerDetail cd9_HD = new ComputerDetail { Name = "Transcend StoreJet 25M3G 2TB", Category = c4, Quantity = 80, Price = 3599, Description = "Жорсткий диск Transcend StoreJet \r\n 25M3G 2TB TS2TSJ25M3G 2.5\r\n USB 3.1 Gen1 External Military Green" };
                ComputerDetail cd10_HD = new ComputerDetail { Name = "Apacer AC236 1TB 5400rpm 8MB", Category = c4, Quantity = 55, Price = 1959, Description = " Жорсткий диск Apacer AC236 1TB \r\n 5400rpm 8MB AP1TBAC236U-1 2.5 \r\n USB 3.1 External Blue" };
                ComputerDetail cd11_HD = new ComputerDetail { Name = "Transcend StoreJet 25H3P 1TB", Category = c4, Quantity = 80, Price = 2849, Description = " Жорсткий диск Transcend StoreJet 25H3P 1TB  \r\n TS1TSJ25H3B 2.5 USB 3.0 External" };
                ComputerDetail cd12_HD = new ComputerDetail { Name = "Seagate SkyHawk 4TB", Category = c4, Quantity = 50, Price = 3859, Description = " Жорсткий диск Seagate SkyHawk 4TB \r\n256MB ST4000VX016 3.5\" SATAIII" };
                ComputerDetail cd13_HD = new ComputerDetail { Name = "Silicon Power Armor A30 1TB", Category = c4, Quantity = 80, Price = 2109, Description = " Жорсткий диск Silicon Power Armor A66 1TB\r\n SP010TBPHD66SS3B 2.5 USB 3.2 External Blue" };
                ComputerDetail cd14_HD = new ComputerDetail { Name = "Western Digital Purple 1TB", Category = c4, Quantity = 50, Price = 2059, Description = " Жорсткий диск Western Digital Purple 1TB  \r\n 64MB 5400rpm WD10PURZ 3.5 SATA III" };


                ComputerDetail cd1_SSD = new ComputerDetail { Name = "SSD Western Digital", Category = c5, Quantity = 70, Price = 3495, Description = "SSD Western Digital PC SN740 1Tb\r\n M.2 2230 PCIE Gen4 x4 NVME \r\n(SDDPTQD-1T00) OEM" };
                ComputerDetail cd2_SSD = new ComputerDetail { Name = "Apacer AS340X 120GB", Category = c5, Quantity = 80, Price = 479, Description = "SSD диск Apacer AS340X 120GB 2.5 \r\n SATAIII 3D NAND (AP120GAS340XC-1)" };
                ComputerDetail cd3_SSD = new ComputerDetail { Name = "Kingston SSDNow A400", Category = c5, Quantity = 70, Price = 1349, Description = "SSD диск Kingston SSDNow A400 480GB \r\n 2.5\" SATAIII 3D V-NAND (SA400S37/480G)" };
                ComputerDetail cd4_SSD = new ComputerDetail { Name = "Gigabyte 240GB", Category = c5, Quantity = 75, Price = 899, Description = "SSD диск Gigabyte 240GB 2.5 \r\n SATAIII NAND TLC (GP-GSTFS31240GNTD)" };
                ComputerDetail cd5_SSD = new ComputerDetail { Name = "Goodram CX400 Gen.2 128GB", Category = c5, Quantity = 70, Price = 489, Description = "SSD диск Goodram CX400 Gen.2 128GB \r\n 2.5 SATAIII 3D NAND TLC (SSDPR-CX400-128-G2)" };
                ComputerDetail cd6_SSD = new ComputerDetail { Name = "Patriot Burst Elite 120GB", Category = c5, Quantity = 70, Price = 439, Description = "SSD диск Patriot Burst Elite 120GB \r\n 2.5 SATAIII TLC (PBE120GS25SSDR)" };
                ComputerDetail cd7_SSD = new ComputerDetail { Name = "Kingston KC600 256GB", Category = c5, Quantity = 70, Price = 1109, Description = "SSD диск Kingston KC600 256GB 2.5 \r\n SATAIII 3D NAND TLC (SKC600/256G)" };
                ComputerDetail cd8_SSD = new ComputerDetail { Name = "Kingston XS2000 Portable 1TB", Category = c5, Quantity = 70, Price = 3799, Description = "SSD диск Kingston XS2000 Portable 1TB \r\n USB 3.2 Gen2 (2x2) Type-C IP55 3D NAND  \r\n (SXS2000/1000G)" };
                ComputerDetail cd9_SSD = new ComputerDetail { Name = "Kingston FURY Renegade 2TB", Category = c5, Quantity = 65, Price = 5999, Description = "SSD диск Kingston FURY Renegade 2TB \r\n M.2 2280 NVMe PCIe Gen 4.0 x4 3D TLC NAND \r\n (SFYRD/2000G)" };
                ComputerDetail cd10_SSD = new ComputerDetail { Name = "Transcend ESD380C 2TB", Category = c5, Quantity = 90, Price = 5299, Description = "SSD диск Transcend ESD380C 2TB \r\n USB 3.1 Type-C 3D NAND TLC Military Green \r\n (TS2TESD380C) External" };
                ComputerDetail cd11_SSD = new ComputerDetail { Name = "Kingston XS1000 Portable 1000GB", Category = c5, Quantity = 70, Price = 3179, Description = "SSD диск Kingston XS1000 Portable 1000GB \r\n USB 3.2 Gen 2 (SXS1000/1000G)" };
                ComputerDetail cd12_SSD = new ComputerDetail { Name = "Kingston XS2000 Portable 4TB", Category = c5, Quantity = 70, Price = 11999, Description = "SSD диск Kingston XS2000 Portable 4TB USB  \r\n 3.2 Gen2 (2x2) Type-C IP55 3D NAND (SXS2000/4000G)" };
                ComputerDetail cd13_SSD = new ComputerDetail { Name = "Samsung 980 Pro 500GB", Category = c5, Quantity = 87, Price = 2949, Description = "SSD диск Samsung 980 Pro 500GB \r\n M.2 PCIe 4.0 x4 V-NAND 3bit MLC \r\n (MZ-V8P500BW)" };
                ComputerDetail cd14_SSD = new ComputerDetail { Name = "Kingston FURY Renegade with Heatsink 4TB", Category = c5, Quantity = 70, Price = 16599, Description = "SSD диск Kingston FURY Renegade with Heatsink 4TB \r\n  NVMe M.2 2280 PCIe 4.0 x4 3D NAND TLC \r\n (SFYRDK/4000G)" };



                ComputerDetail cd1_SP = new ComputerDetail { Name = "DeepCool PF750 750W ", Category = c7, Quantity = 100, Price = 2299, Description = "Блок живлення DeepCool PF750 \r\n750W (R-PF750D-HA0B-EU)" };
                ComputerDetail cd2_SP = new ComputerDetail { Name = "System Power 10 750W", Category = c7, Quantity = 50, Price = 3349, Description = "Блок живлення System Power 10 750W (BN329)" };
                ComputerDetail cd3_SP = new ComputerDetail { Name = "RZTK PcCooler HW600", Category = c7, Quantity = 100, Price = 1499, Description = "Блок живлення RZTK PcCooler HW600-NP 600W" };
                ComputerDetail cd4_SP = new ComputerDetail { Name = "Chieftec GPS-600A8", Category = c7, Quantity = 80, Price = 1989, Description = "Блок живлення Chieftec GPS-600A8 600W" };
                ComputerDetail cd5_SP = new ComputerDetail { Name = "be quiet! Straight Power 12 1200 Вт", Category = c7, Quantity = 100, Price = 10449, Description = "Блок живлення be quiet!\r\n Straight Power 12 1200 Вт (BN339)" };
                ComputerDetail cd6_SP = new ComputerDetail { Name = "ASUS TUF Gaming 1000 Вт", Category = c7, Quantity = 50, Price = 8069, Description = "Блок живлення ASUS TUF Gaming 1000 Вт\r\n Gold (TUF-GAMING-1000G)" };
                ComputerDetail cd7_SP = new ComputerDetail { Name = "MSI MAG A550BN", Category = c7, Quantity = 100, Price = 1999, Description = "Блок живлення MSI MAG A550BN 550W" };
                ComputerDetail cd8_SP = new ComputerDetail { Name = "Chieftec Proton", Category = c7, Quantity = 50, Price = 5109, Description = "Блок живлення Chieftec Proton BDF-1000C 1000W" };
                ComputerDetail cd9_SP = new ComputerDetail { Name = "Gigabyte 750W 80+ Gold", Category = c7, Quantity = 100, Price = 4099, Description = "Блок живлення Gigabyte 750W \r\n 80+ Gold (UD750GM)" };
                ComputerDetail cd10_SP = new ComputerDetail { Name = "ASUS ROG Strix 850W", Category = c7, Quantity = 50, Price = 6399, Description = "Блок живлення ASUS ROG Strix 850W \r\n Gold PSU (ROG-STRIX-850G)" };
                ComputerDetail cd11_SP = new ComputerDetail { Name = "be quiet! Straight Power 11 1000W", Category = c7, Quantity = 100, Price = 6799, Description = "Блок живлення be quiet! \r\n Straight Power 11 1000W (BN285)" };
                ComputerDetail cd12_SP = new ComputerDetail { Name = "ASUS ROG-THOR-1200P2", Category = c7, Quantity = 50, Price = 20479, Description = "Блок живлення ASUS ROG-THOR-1200P2-GAMING" };
                ComputerDetail cd13_SP = new ComputerDetail { Name = "LogicPower ATX-800W", Category = c7, Quantity = 100, Price = 1689, Description = "Блок живлення LogicPower ATX-800W \r\n APFC 80+ Bronze (LP10228)" };
                ComputerDetail cd14_SP = new ComputerDetail { Name = "Chieftec Chieftronic PowerUp GPX-850FC", Category = c7, Quantity = 50, Price = 3699, Description = "Блок живлення Chieftec Chieftronic \r\n PowerUp GPX-850FC 850W 80PLUS Gold" };



                ComputerDetails.Add(cd1_RAM);
                ComputerDetails.Add(cd2_RAM);
                ComputerDetails.Add(cd3_RAM);
                ComputerDetails.Add(cd4_RAM);
                ComputerDetails.Add(cd5_RAM);
                ComputerDetails.Add(cd6_RAM);
                ComputerDetails.Add(cd7_RAM);
                ComputerDetails.Add(cd8_RAM);
                ComputerDetails.Add(cd9_RAM);
                ComputerDetails.Add(cd10_RAM);
                ComputerDetails.Add(cd11_RAM);
                ComputerDetails.Add(cd12_RAM);
                ComputerDetails.Add(cd13_RAM);
                ComputerDetails.Add(cd14_RAM);

                ComputerDetails.Add(cd1_CPU);
                ComputerDetails.Add(cd2_CPU);
                ComputerDetails.Add(cd3_CPU);
                ComputerDetails.Add(cd4_CPU);
                ComputerDetails.Add(cd5_CPU);
                ComputerDetails.Add(cd6_CPU);
                ComputerDetails.Add(cd7_CPU);
                ComputerDetails.Add(cd8_CPU);
                ComputerDetails.Add(cd9_CPU);
                ComputerDetails.Add(cd10_CPU);
                ComputerDetails.Add(cd11_CPU);
                ComputerDetails.Add(cd12_CPU);
                ComputerDetails.Add(cd13_CPU);
                ComputerDetails.Add(cd14_CPU);

                ComputerDetails.Add(cd1_SP);
                ComputerDetails.Add(cd2_SP);
                ComputerDetails.Add(cd3_SP);
                ComputerDetails.Add(cd4_SP);
                ComputerDetails.Add(cd5_SP);
                ComputerDetails.Add(cd6_SP);
                ComputerDetails.Add(cd7_SP);
                ComputerDetails.Add(cd8_SP);
                ComputerDetails.Add(cd9_SP);
                ComputerDetails.Add(cd10_SP);
                ComputerDetails.Add(cd11_SP);
                ComputerDetails.Add(cd12_SP);
                ComputerDetails.Add(cd13_SP);
                ComputerDetails.Add(cd14_SP);

                ComputerDetails.Add(cd1_HD);
                ComputerDetails.Add(cd2_HD);
                ComputerDetails.Add(cd3_HD);
                ComputerDetails.Add(cd4_HD);
                ComputerDetails.Add(cd5_HD);
                ComputerDetails.Add(cd6_HD);
                ComputerDetails.Add(cd7_HD);
                ComputerDetails.Add(cd8_HD);
                ComputerDetails.Add(cd9_HD);
                ComputerDetails.Add(cd10_HD);
                ComputerDetails.Add(cd11_HD);
                ComputerDetails.Add(cd12_HD);
                ComputerDetails.Add(cd13_HD);
                ComputerDetails.Add(cd14_HD);

                ComputerDetails.Add(cd1_SSD);
                ComputerDetails.Add(cd2_SSD);
                ComputerDetails.Add(cd3_SSD);
                ComputerDetails.Add(cd4_SSD);
                ComputerDetails.Add(cd5_SSD);
                ComputerDetails.Add(cd6_SSD);
                ComputerDetails.Add(cd7_SSD);
                ComputerDetails.Add(cd8_SSD);
                ComputerDetails.Add(cd9_SSD);
                ComputerDetails.Add(cd10_SSD);
                ComputerDetails.Add(cd11_SSD);
                ComputerDetails.Add(cd12_SSD);
                ComputerDetails.Add(cd13_SSD);
                ComputerDetails.Add(cd14_SSD);

                ComputerDetails.Add(cd1_VC);
                ComputerDetails.Add(cd2_VC);
                ComputerDetails.Add(cd3_VC);
                ComputerDetails.Add(cd4_VC);
                ComputerDetails.Add(cd5_VC);
                ComputerDetails.Add(cd6_VC);
                ComputerDetails.Add(cd7_VC);
                ComputerDetails.Add(cd8_VC);
                ComputerDetails.Add(cd9_VC);
                ComputerDetails.Add(cd10_VC);
                ComputerDetails.Add(cd11_VC);
                ComputerDetails.Add(cd12_VC);
                ComputerDetails.Add(cd13_VC);
                ComputerDetails.Add(cd14_VC);

                ComputerDetails.Add(cd1_Motherboard);
                ComputerDetails.Add(cd2_Motherboard);
                ComputerDetails.Add(cd3_Motherboard);
                ComputerDetails.Add(cd4_Motherboard);
                ComputerDetails.Add(cd5_Motherboard);
                ComputerDetails.Add(cd6_Motherboard);
                ComputerDetails.Add(cd7_Motherboard);
                ComputerDetails.Add(cd8_Motherboard);
                ComputerDetails.Add(cd9_Motherboard);
                ComputerDetails.Add(cd10_Motherboard);
                ComputerDetails.Add(cd11_Motherboard);
                ComputerDetails.Add(cd12_Motherboard);
                ComputerDetails.Add(cd13_Motherboard);
                ComputerDetails.Add(cd14_Motherboard);


                ComputerType ct1 = new ComputerType { Name = "Desktop" };
                ComputerType ct2 = new ComputerType { Name = "Laptop" };
                ComputerTypes.Add(ct1);
                ComputerTypes.Add(ct2);

                List<ComputerDetail> list1 = new List<ComputerDetail>();
                list1.Add(cd1_RAM);
                list1.Add(cd1_Motherboard);
                list1.Add(cd1_CPU);
                list1.Add(cd1_HD);
                list1.Add(cd1_SSD);
                list1.Add(cd1_VC);
                list1.Add(cd1_SP);

                List<ComputerDetail> list2 = new List<ComputerDetail>();
                list2.Add(cd2_RAM);
                list2.Add(cd2_Motherboard);
                list2.Add(cd2_CPU);
                list2.Add(cd2_HD);
                list2.Add(cd2_SSD);
                list2.Add(cd2_VC);
                list2.Add(cd2_SP);

                List<ComputerDetail> list3 = new List<ComputerDetail>();
                list3.Add(cd3_RAM);
                list3.Add(cd3_Motherboard);
                list3.Add(cd3_CPU);
                list3.Add(cd3_HD);
                list3.Add(cd3_SSD);
                list3.Add(cd3_VC);
                list3.Add(cd3_SP);

                List<ComputerDetail> list4 = new List<ComputerDetail>();
                list4.Add(cd4_RAM);
                list4.Add(cd4_Motherboard);
                list4.Add(cd4_CPU);
                list4.Add(cd4_HD);
                list4.Add(cd4_SSD);
                list4.Add(cd4_VC);
                list4.Add(cd4_SP);

                List<ComputerDetail> list5 = new List<ComputerDetail>();
                list5.Add(cd5_RAM);
                list5.Add(cd5_Motherboard);
                list5.Add(cd5_CPU);
                list5.Add(cd5_HD);
                list5.Add(cd5_SSD);
                list5.Add(cd5_VC);
                list5.Add(cd5_SP);

                List<ComputerDetail> list6 = new List<ComputerDetail>();
                list6.Add(cd6_RAM);
                list6.Add(cd6_Motherboard);
                list6.Add(cd6_CPU);
                list6.Add(cd6_HD);
                list6.Add(cd6_SSD);
                list6.Add(cd6_VC);
                list6.Add(cd6_SP);

                List<ComputerDetail> list7 = new List<ComputerDetail>();
                list7.Add(cd7_RAM);
                list7.Add(cd7_Motherboard);
                list7.Add(cd7_CPU);
                list7.Add(cd7_HD);
                list7.Add(cd7_SSD);
                list7.Add(cd7_VC);
                list7.Add(cd7_SP);

                List<ComputerDetail> list8 = new List<ComputerDetail>();
                list8.Add(cd8_RAM);
                list8.Add(cd8_Motherboard);
                list8.Add(cd8_CPU);
                list8.Add(cd8_HD);
                list8.Add(cd8_SSD);
                list8.Add(cd8_VC);
                list8.Add(cd8_SP);

                List<ComputerDetail> list9 = new List<ComputerDetail>();
                list9.Add(cd9_RAM);
                list9.Add(cd9_Motherboard);
                list9.Add(cd9_CPU);
                list9.Add(cd9_HD);
                list9.Add(cd9_SSD);
                list9.Add(cd9_VC);
                list9.Add(cd9_SP);


                Computer comp1 = new Computer { Name = "Tor AMD Ryzen", ComputerType = ct1, ComputerDetails = list1, Quantity = 5, Price = 92000 };
                Computer comp2 = new Computer { Name = "ARTLINE Business", ComputerType = ct2, ComputerDetails = list2, Quantity = 9, Price = 68000 };
                Computer comp3 = new Computer { Name = "Lenovo IdeaCentre ", ComputerType = ct1, ComputerDetails = list3, Quantity = 8, Price = 100000 }; 

                Computer comp4 = new Computer { Name = "HP ProDesk ", ComputerType = ct1, ComputerDetails = list4, Quantity = 15, Price = 49000 }; 
                Computer comp5 = new Computer { Name = "Dell Vostro 15 ", ComputerType = ct2, ComputerDetails = list5, Quantity = 12, Price = 45000 };
                Computer comp6 = new Computer { Name = "Asus PC Gamer ", ComputerType = ct1, ComputerDetails = list6, Quantity = 15, Price = 65000 };
                Computer comp7 = new Computer { Name = "Lenovo IdeaPad ", ComputerType = ct2, ComputerDetails = list7, Quantity = 7, Price = 57000 };
                Computer comp8 = new Computer { Name = "CyberPowerPC ", ComputerType = ct1, ComputerDetails = list8, Quantity = 3, Price = 99000 };
                Computer comp9 = new Computer { Name = "HP 470 G10 ", ComputerType = ct2, ComputerDetails = list9, Quantity = 4, Price = 55000 };


                Computers.Add(comp1);
                Computers.Add(comp2);
                Computers.Add(comp3);
                Computers.Add(comp4);
                Computers.Add(comp5);
                Computers.Add(comp6);
                Computers.Add(comp7);
                Computers.Add(comp8);
                Computers.Add(comp9);


                Customer customer = new Customer { Name = "Vitaliy", Email = "polyanskiy@itstep.academy", Points = 100 };

                Customers.Add(customer);


                Seller seller1 = new Seller { Name = "Iryna", Email = "chumachenko.bc@gmail.com" };
                Seller seller2 = new Seller { Name = "Anastasia", Email = "nastasia.schull@gmail.com" };
                Seller seller3 = new Seller { Name = "Vlad", Email = "vlad@gmail.com" };


                Sellers.AddRange(seller1, seller2, seller3);
                SaveChanges();
            }

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerDetail> ComputerDetails { get; set; }
        public DbSet<OrderCart> OrderCarts { get; set; }
        public DbSet<Peripherals> Peripheralss { get; set; }
        public DbSet<PeripheralsType> PeripheralsType { get; set; }
        public DbSet<ComputerType> ComputerTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            optionsBuilder.UseLazyLoadingProxies();//@"Server=LAPTOP-DG4K3PMR;Database=ComputerStore;Integrated Security=SSPI;TrustServerCertificate=true", options => options.EnableRetryOnFailure());

        }

    }
}

