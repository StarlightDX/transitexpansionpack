using System;
using System.Collections.Generic;
using GTA;
using GTA.Math;
using GTA.Native;


public class TransitExpansionPackSpawner : Script
{
    public class VehicleData
    {
        public string ModelName;
        public string Plate;
        public int PrimaryLivery;      // LCD Sign for route number
        public int RoofLivery;         // Paint/Repaint Livery for branding
        public Dictionary<VehicleMod, int> Mods;
        public List<int> Extras;
        public bool Turbo;

        public VehicleData()
        {
            Plate = "CUSTOM";
            PrimaryLivery = 0;
            RoofLivery = -1; // -1 = Spawn with a random LCD from image index
            Mods = new Dictionary<VehicleMod, int>(); // All modkit options added
            Extras = new List<int>();
            Turbo = false;
        }
    }

    // Livery/RoofLivery: 10 in script = 11 in Menyoo

    public class VehicleSpawnPoint
    {
        public Vector3 Position;
        public float Heading;
        public Vehicle SpawnedVehicle;
        public VehicleData VehicleData;
    }

    private List<VehicleSpawnPoint> spawnPoints = new List<VehicleSpawnPoint>();
    private List<VehicleData> vehicles = new List<VehicleData>();
    private float spawnDistance = 300f;
    private float despawnDistance = 240f;

    public TransitExpansionPackSpawner()
    {
        Tick += OnTick;

        // CVehicles

        // Modkit variation amended due to lack of documentation and unwilling responses

        // Dashound Bus Center

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(447.87f, -566.84f, 28.49f),
            Heading = 159.96f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobussuper",
                Plate = "09JSA629",
                PrimaryLivery = 0,
                RoofLivery = 16,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(450.17f, -591.81f, 28.49f),
            Heading = 89.38f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusturbo",
                Plate = "08ZQB128",
                PrimaryLivery = 13,
                RoofLivery = 9,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(439.71f, -572.19f, 28.49f),
            Heading = 143.06f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobuselectric",
                Plate = "21RUU625",
                PrimaryLivery = 0,
                RoofLivery = 7,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(417.31f, -613.44f, 28.59f),
            Heading = 0.19f,
            VehicleData = new VehicleData
            {
                ModelName = "citybusmethanol",
                Plate = "07MNJ330",
                PrimaryLivery = 24,
                RoofLivery = 20,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Maze Bank Arena

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-142.71f, -2032.97f, 22.94f),
            Heading = -104.77f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus2",
                Plate = "80QWM365",
                PrimaryLivery = 13,
                RoofLivery = 1,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-147.53f, -2046.27f, 22.95f),
            Heading = -110.07f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusrental",
                Plate = "06JRS572",
                PrimaryLivery = 0,
                RoofLivery = 10,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-143.61f, -2042.73f, 22.72f),
            Heading = -104.81f,
            VehicleData = new VehicleData
            {
                ModelName = "rentalbus1",
                Plate = "69DWW909",
                PrimaryLivery = 0,
                RoofLivery = 6,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Paleto Bay Bus Station

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(203.69f, 6606.03f, 31.62f),
            Heading = 3.67f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusturbo",
                Plate = "08ZQB129",
                PrimaryLivery = 10,
                RoofLivery = 9,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(204.84f, 6591.23f, 31.65f),
            Heading = 1.84f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus3",
                Plate = "03WRC137",
                PrimaryLivery = 26,
                RoofLivery = 6,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(172.57f, 6624.69f, 31.72f),
            Heading = 133.25f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus1",
                Plate = "86WDY226",
                PrimaryLivery = 28,
                RoofLivery = 17,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Palomino Freeway Retail Park

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(2595.42f, 339.94f, 108.36f),
            Heading = -2.53f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusturbo",
                Plate = "08ZQB104",
                PrimaryLivery = 1,
                RoofLivery = 9,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(2556.50f, 407.86f, 108.44f),
            Heading = 134.58f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus2",
                Plate = "42LWB821",
                PrimaryLivery = 27,
                RoofLivery = 17,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Lower Rockford Hills Silver Line Instance

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-278.93f, -619.77f, 33.33f),
            Heading = 94.15f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobussuper",
                Plate = "80IYN506",
                PrimaryLivery = 23,
                RoofLivery = 11,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Strawberry Bus Exchange

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(206.35f, -1229.98f, 29.16f),
            Heading = -176.4f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobushybrid",
                Plate = "03WCM561",
                PrimaryLivery = 23,
                RoofLivery = 17,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Park & Ride (Legion Square)

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(203.25f, -846.23f, 30.53f),
            Heading = -110.11f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobuselectric",
                Plate = "21RUU629",
                PrimaryLivery = 12,
                RoofLivery = 25,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Park & Ride (L.S.I.A)

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-718.44f, -2224.93f, 5.79f),
            Heading = -91.09f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobuselectric",
                Plate = "21RUU633",
                PrimaryLivery = 13,
                RoofLivery = 26,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Park & Ride (Vinewood Bowl)

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(707.41f, 660.24f, 128.90f),
            Heading = 10.15f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobus1",
                Plate = "47NZZ865",
                PrimaryLivery = 1,
                RoofLivery = 10,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Los Santos International Airport

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-896.49f, -2702.33f, 13.69f),
            Heading = -30.83f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusturbo",
                Plate = "08ZQB120",
                PrimaryLivery = 20,
                RoofLivery = 10,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Los Santos International Airport - Crastenburg Hotel

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-867.20f, -2046.59f, 9.06f),
            Heading = 135.01f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusturbo",
                Plate = "08ZQB119",
                PrimaryLivery = 1,
                RoofLivery = 8,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-877.42f, -2056.81f, 8.81f),
            Heading = 135.01f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobus2",
                Plate = "63JDB628",
                PrimaryLivery = 0,
                RoofLivery = 8,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-900.34f, -2103.86f, 8.54f),
            Heading = -44.49f,
            VehicleData = new VehicleData
            {
                ModelName = "rentalbus1",
                Plate = "80SSH375",
                PrimaryLivery = 0,
                RoofLivery = 13,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-901.57f, -2080.82f, 9.63f),
            Heading = 134.08f,
            VehicleData = new VehicleData
            {
                ModelName = "intercitycoach1",
                Plate = "08MEZ606",
                PrimaryLivery = 0,
                RoofLivery = 9,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Escalera Rental

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-895.88f, -2251.40f, 6.70f),
            Heading = -119.56f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusrental",
                Plate = "44WRJ289",
                PrimaryLivery = 0,
                RoofLivery = 9,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Touchdown Rental

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-812.37f, -2341.17f, 14.56f),
            Heading = 60.17f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusrental",
                Plate = "49FSS970",
                PrimaryLivery = 0,
                RoofLivery = 10,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-802.20f, -2346.90f, 14.33f),
            Heading = 59.67f,
            VehicleData = new VehicleData
            {
                ModelName = "rentalbus1",
                Plate = "49FSS970",
                PrimaryLivery = 0,
                RoofLivery = 1,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Bullet Bus & Coach Lines Depot

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(1003.70f, -2354.31f, 30.50f),
            Heading = -93.78f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusrental",
                Plate = "25RRG883",
                PrimaryLivery = 0,
                RoofLivery = 12,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(1004.04f, -2349.88f, 30.50f),
            Heading = -95.45f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusrental",
                Plate = "25RRG894",
                PrimaryLivery = 0,
                RoofLivery = 13,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(1004.31f, -2345.68f, 30.50f),
            Heading = -98.28f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusrental",
                Plate = "25RRG896",
                PrimaryLivery = 0,
                RoofLivery = 13,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(1005.22f, -2338.69f, 30.50f),
            Heading = -98.13f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusrental",
                Plate = "25RRG897",
                PrimaryLivery = 0,
                RoofLivery = 13,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(1001.90f, -2324.43f, 31.34f),
            Heading = 173.75f,
            VehicleData = new VehicleData
            {
                ModelName = "intercitycoach1",
                Plate = "80DJP617",
                PrimaryLivery = 0,
                RoofLivery = 5,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(1006.03f, -2324.87f, 31.34f),
            Heading = 173.75f,
            VehicleData = new VehicleData
            {
                ModelName = "intercitycoach1",
                Plate = "80DJP618",
                PrimaryLivery = 0,
                RoofLivery = 5,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(1011.53f, -2325.47f, 31.34f),
            Heading = 173.75f,
            VehicleData = new VehicleData
            {
                ModelName = "intercitycoach1",
                Plate = "80DJP619",
                PrimaryLivery = 0,
                RoofLivery = 6,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Blaine County Transit Paleto Bay Depot

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(71.22f, 6319.99f, 31.22f),
            Heading = 28.35f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobus1",
                Plate = "67BJG462",
                PrimaryLivery = 0,
                RoofLivery = 21,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(74.51f, 6321.76f, 31.22f),
            Heading = 28.35f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobus1",
                Plate = "09UCO011",
                PrimaryLivery = 0,
                RoofLivery = 22,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(64.03f, 6333.31f, 31.21f),
            Heading = 28.35f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus1",
                Plate = "66ZRV902",
                PrimaryLivery = 0,
                RoofLivery = 18,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(67.35f, 6335.11f, 31.21f),
            Heading = 28.35f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus1",
                Plate = "66ZRV907",
                PrimaryLivery = 0,
                RoofLivery = 17,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(75.46f, 6327.65f, 31.21f),
            Heading = 28.35f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus1",
                Plate = "66ZRV911",
                PrimaryLivery = 0,
                RoofLivery = 18,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Los Santos Transit Depot L.S.I.A

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-975.65f, -2367.74f, 13.94f),
            Heading = 60.35f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobus1",
                Plate = "02UXB054",
                PrimaryLivery = 0,
                RoofLivery = 0,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-977.70f, -2371.32f, 13.94f),
            Heading = 60.35f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobus1",
                Plate = "02UXB077",
                PrimaryLivery = 0,
                RoofLivery = 11,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-979.76f, -2374.94f, 13.94f),
            Heading = 60.35f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusturbo",
                Plate = "08ZQB126",
                PrimaryLivery = 0,
                RoofLivery = 10,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-981.83f, -2378.60f, 13.94f),
            Heading = 60.35f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusturbo",
                Plate = "08ZQB120",
                PrimaryLivery = 0,
                RoofLivery = 10,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-984.08f, -2382.54f, 13.94f),
            Heading = 60.35f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobusturbo",
                Plate = "08ZQB129",
                PrimaryLivery = 0,
                RoofLivery = 10,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-991.21f, -2403.59f, 13.93f),
            Heading = -29.94f,
            VehicleData = new VehicleData
            {
                ModelName = "citybusmethanol",
                Plate = "07MNJ335",
                PrimaryLivery = 0,
                RoofLivery = 20,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-994.99f, -2401.42f, 13.93f),
            Heading = -29.94f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus2",
                Plate = "61BDX615",
                PrimaryLivery = 0,
                RoofLivery = 2,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-999.00f, -2399.13f, 13.93f),
            Heading = -29.94f,
            VehicleData = new VehicleData
            {
                ModelName = "citybusmethanol",
                Plate = "07MNJ333",
                PrimaryLivery = 0,
                RoofLivery = 20,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-984.57f, -2387.63f, 13.71f),
            Heading = 60.43f,
            VehicleData = new VehicleData
            {
                ModelName = "rentalbus1",
                Plate = "00STT655",
                PrimaryLivery = 0,
                RoofLivery = 6,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-986.25f, -2390.56f, 13.71f),
            Heading = 60.43f,
            VehicleData = new VehicleData
            {
                ModelName = "rentalbus1",
                Plate = "00STT657",
                PrimaryLivery = 0,
                RoofLivery = 6,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-992.12f, -2383.33f, 13.71f),
            Heading = 60.43f,
            VehicleData = new VehicleData
            {
                ModelName = "rentalbus1",
                Plate = "00STT662",
                PrimaryLivery = 0,
                RoofLivery = 7,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // East Vinewood Bus Stands

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(950.95f, 162.70f, 81.66f),
            Heading = 80.36f,
            VehicleData = new VehicleData
            {
                ModelName = "intercitycoach2",
                Plate = "09UCZ575",
                PrimaryLivery = 0,
                RoofLivery = 3,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(955.34f, 168.34f, 81.66f),
            Heading = 79.78f,
            VehicleData = new VehicleData
            {
                ModelName = "intercitycoach1",
                Plate = "47HSC478",
                PrimaryLivery = 0,
                RoofLivery = 8,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        // Del Perro Beach

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-2007.90f, -462.38f, 11.49f),
            Heading = -129.16f,
            VehicleData = new VehicleData
            {
                ModelName = "citybus3",
                Plate = "42SXZ211",
                PrimaryLivery = 0,
                RoofLivery = 8,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-1996.74f, -471.47f, 11.56f),
            Heading = -129.04f,
            VehicleData = new VehicleData
            {
                ModelName = "metrobussuper",
                Plate = "41VRM175",
                PrimaryLivery = 1,
                RoofLivery = 8,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

        spawnPoints.Add(new VehicleSpawnPoint
        {
            Position = new Vector3(-1978.38f, -487.66f, 12.56f),
            Heading = -136.76f,
            VehicleData = new VehicleData
            {
                ModelName = "intercitycoach1",
                Plate = "86FCJ816",
                PrimaryLivery = 0,
                RoofLivery = 5,
                Mods = new Dictionary<VehicleMod, int>(),
                Extras = new List<int> { 0 },
                Turbo = false
            }
        });

    }

    private void OnTick(object sender, EventArgs e)
    {
        Vector3 playerPos = Game.Player.Character.Position;


        foreach (VehicleSpawnPoint sp in spawnPoints)
        {
            float dist = playerPos.DistanceTo(sp.Position);

            // Spawn if close enough, should save on fps however this was initially tested on an APU so the results are dubious 
            if (dist <= spawnDistance && sp.SpawnedVehicle == null)
            {
                VehicleData vData = sp.VehicleData;

                Model model = new Model(vData.ModelName);
                model.Request(5000);
                if (!model.IsLoaded)
                {
                    UI.Notify("Failed to load model: " + vData.ModelName);
                    continue;
                }

                Vehicle veh = World.CreateVehicle(model, sp.Position, sp.Heading);
                if (veh == null) continue;

                // License plate number, cannot find the license plate type
                veh.NumberPlate = vData.Plate;

                // Apply primary livery (body)
                if (veh.LiveryCount > 0 && vData.PrimaryLivery < veh.LiveryCount)
                {
                    veh.Livery = vData.PrimaryLivery;
                }

                // Apply general mods
                foreach (var mod in vData.Mods)
                {
                    if (veh.GetModCount(mod.Key) > 0)
                        veh.SetMod(mod.Key, mod.Value, false);
                }

                // Apply LCD Sign using native, reminder to ask why this doesn't have a scripthook call
                if (vData.RoofLivery >= 0)
                {
                    Function.Call((Hash)0xA6D3A8750DC73270, veh.Handle, vData.RoofLivery);
                }

                // Apply extras
                foreach (int extra in vData.Extras)
                {
                    if (veh.ExtraExists(extra))
                        veh.ToggleExtra(extra, true);
                }

                // Apply turbo
                if (vData.Turbo)
                    veh.ToggleMod(VehicleToggleMod.Turbo, true);

               // // Lock the vehicle so you cannot enter as it will despawn if you drive it from origin point. Remove this function when spawns are figured out
                veh.LockStatus = VehicleLockStatus.Locked;
               
                sp.SpawnedVehicle = veh;
            }

            // Despawn if too far
            if (dist > despawnDistance && sp.SpawnedVehicle != null)
            {
                sp.SpawnedVehicle.Delete();
                sp.SpawnedVehicle = null;
            }
        }
    }
}
