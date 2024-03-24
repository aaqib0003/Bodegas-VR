using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedPalletInfo : MonoBehaviour
{
    public bool crearStart = true;
    public string peso = "66 KG";
    public string tamano = "12x23";
    public string fechaVece = "17/09/2025";
    public string origen = "San Gil";
    public string destino = "Bogota";
    public string precio = "Bogota";
    public string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
    public bool malEsstado = false;
    public Material babMaterial;
    public MeshRenderer meshbox;
    public MerchLabel merchLabel;
    public string ubicacionAux = "";
    [Header("MATERIALES DE LA CAJA")]
    public Material burbujaMaterial;
    public Material espumaMaterial;
    public Material cajasMaterial;


    private string[] pesoArray = new string[] {
        "50 Kg",
        "75 Kg",
        "1 Kg",
        "30 Kg",
        "60 Kg",
        "80 Kg",
        "40 Kg",
        "90 Kg",
        "35 Kg",
        "55 Kg"
    };

    private string[] tamanoArray = new string[] {
       "(15 x 10 x 5)",
        "(20 x 15 x 8)",
        "(30 x 20 x 10)",
        "(12 x 8 x 4)",
        "(18 x 12 x 6)",
        "(25 x 15 x 8)",
        "(14 x 9 x 5)",
        "(22 x 16 x 7)",
        "(35 x 25 x 12)",
        "(16 x 11 x 6)"
    };

    private string[] fechaVeceArray = new string[] {
        "2023-05-01",
        "2023-06-15",
        "2023-04-10",
        "2023-07-20",
        "2023-08-12",
        "2023-03-05",
        "2023-09-30",
        "2023-02-18",
        "2023-10-25",
        "2023-11-15"
    };

    private string[] origenArray = new string[] {
        "Bogotá",
        "Cali",
        "Cartagena",
        "Medellín",
        "Barranquilla",
        "Bogotá",
        "Cali",
        "Cartagena",
        "Medellín",
        "Barranquilla"
    };

    private string[] precioArray = new string[] {
        "50,000",
        "70,000",
        "120,000",
        "40,000",
        "90,000",
        "80,000",
        "60,000",
        "110,000",
        "45,000",
        "75,000"
    };

    private string[] descriptionArray = new string[] {
        "Herramientas eléctricas: Taladro de alta potencia",
        "Equipos de jardinería: Cortadora de césped automática",
        "Electrónicos portátiles: Tabletas de última generación",
        "Artículos de limpieza: Hidrolavadora inalámbrica portátil recargable",
        "Productos de seguridad: Cámaras de vigilancia de alta resolución",
        "Suministros de oficina: Paquetes de papel y material de oficina",
        "Artículos para el hogar: Juegos de sábanas y toallas",
        "Juguetes y entretenimiento: Drones con cámara integrada",
        "Suministros de construcción: Cajas de herramientas completas",
        "Equipos deportivos: Conjuntos de pesas y accesorios",
        "Suministros de iluminación: Lámparas LED de alta eficiencia",
        "Equipos de mantenimiento: Aspiradoras industriales de última tecnología",
        "Artículos de seguridad: Cajas fuertes electrónicas",
        "Herramientas manuales: Juegos de llaves de alta resistencia",
        "Suministros de embalaje: Cintas adhesivas y sellos de seguridad",
        "Artículos de decoración: Juegos de cuadros y espejos decorativos",
        "Electrónicos de entretenimiento: Consolas de videojuegos y accesorios",
        "Suministros de limpieza industrial: Desengrasantes y productos de limpieza a granel",
        "Artículos de oficina avanzados: Impresoras multifunción de alta velocidad",
        "Equipos de ejercicio: Bicicletas estáticas y accesorios fitness"
    };

    void Start() {
        if (crearStart)
        {
            establcerContenido();
        }
    }

    public void establcerContenido()
    {
        peso = pesoArray[Random.Range(0, pesoArray.Length)];
        tamano = tamanoArray[Random.Range(0, tamanoArray.Length)];
        fechaVece = fechaVeceArray[Random.Range(0, fechaVeceArray.Length)];
        origen = origenArray[Random.Range(0, origenArray.Length)];
        precio = precioArray[Random.Range(0, precioArray.Length)];
        description = descriptionArray[Random.Range(0, descriptionArray.Length)];
        updateTiket();
    }

    private void updateTiket() {
        if (merchLabel) {
            //merchLabel.aisle.text = "03";
            //merchLabel.shelf.text = "E";
            //merchLabel.level.text = "02";

            merchLabel.boxQT.text = peso;
            merchLabel.description.text = description;
            merchLabel.palletQT.text = destino;
        }
    }

    public void setUbicacion(string storageCode) {
        string[] storageCodeSplit = storageCode.Split('-');
        
        merchLabel.aisle.text = storageCodeSplit[0];
        merchLabel.shelf.text = storageCodeSplit[1];
        merchLabel.level.text = storageCodeSplit[2];

        ubicacionAux = storageCode;
    }

    public void setMaterial(string material) {
        switch (material)  {
            case "burbuja":
                meshbox.material = burbujaMaterial;
                break;
            case "espuma":
                meshbox.material = espumaMaterial;
                break;
            case "cajas":
                meshbox.material = cajasMaterial;
                break;
        }
    }

    //cambiar el material por el danado
    public void setMalEstado() {
        malEsstado = true;
        meshbox.material = babMaterial;
    }


}
