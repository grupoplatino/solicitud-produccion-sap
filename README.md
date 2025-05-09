<div align="center">
  <h1>Solicitud de Producción</h1>
  <p>El proyecto Solicitud de Producción SAP es un formulario diseñado para interactuar con un UDO (User Defined Object) en SAP Business One. Este formulario permite gestionar solicitudes de producción de manera eficiente antes de generar las órdenes de fabricación.</p>
  <img src="https://img.shields.io/badge/versión-0.0.0-blue">
  <img src="https://img.shields.io/github/languages/top/tommysvs/solicitud-produccion-sap">
</div>

## Tabla de Contenidos

1. [Características principales](#características-principales)
2. [Requisitos previos](#requisitos-previos)
3. [Instalación](#instalación)
4. [Uso](#uso)
5. [Detalles Técnicos](#detalles-técnicos)

## Características principales

- Interfaz personalizada para gestionar solicitudes de producción.
- Integración con SAP Business One a través de objetos definidos por el usuario (UDO).
- Gestión eficiente de datos relacionados con la producción.

## Requisitos previos

- **Visual Studio 2019** para asegurar compatibilidad con SAP Business One.
- **SAP Business One** instalado y configurado.
- Acceso al **SLD (System Landscape Directory)** de SAP para la instalación del addon.
- Acceso administrativo para crear tablas y objetos definidos por el usuario (UDO) en SAP.
- .NET Framework 4.8 o superior.

## Instalación

1. Clona este repositorio:
   ```bash
   git clone https://github.com/tommysvs/solicitud-produccion-sap.git
   ```
2. Configura tu entorno de desarrollo siguiendo los pasos en la documentación oficial de SAP Business One SDK.
3. Carga la solución en Visual Studio 2019.
4. Compila y ejecuta el proyecto.
5. Instala el formulario utilizando el acceso al SLD de SAP.

## Uso

El formulario **Solicitud de Producción** se utiliza para gestionar las solicitudes de producción antes de generar las órdenes de fabricación. Los pasos principales son:

1. Inicia el formulario desde SAP Business One.
2. Completa el formulario de solicitud de producción con los datos requeridos.
3. Guarda y envía la solicitud para que quede registrada en SAP Business One como una pre-orden de fabricación.

Este proceso permite planificar de manera eficiente las órdenes de fabricación basadas en las solicitudes registradas.

## Detalles Técnicos

### Campos a crearse en SAP

Para que el formulario **Solicitud de Producción** funcione correctamente, es necesario crear los siguientes campos en las tablas que utiliza el UDO (User Defined Object) en SAP Business One. Estas tablas almacenan la información clave sobre las solicitudes de producción y permiten la integración fluida con el sistema. Asegúrate de que estos campos se configuren con sus respectivos tipos de datos y restricciones para garantizar el correcto funcionamiento del formulario.

#### Tabla: `@SOLI_PROD_ENC`

| **Campo**           | **Tipo de Datos**       | **Longitud** | **Descripción**                             |
|----------------------|-------------------------|--------------|---------------------------------------------|
| `ItemCode`          | `nvarchar`             | `50`         | Número de producto                          |
| `ProdName`          | `nvarchar`             | `100`        | Descripción del producto                    |
| `PlannedQty`        | `decimal`              | `21,6`       | Cantidad planificada                        |
| `Warehouse`         | `nvarchar`             | `8`          | Almacén                                     |
| `Priority`          | `int`                  | `6`          | Prioridad                                   |
| `PostDate`          | `date`                 | `N/A`        | Fecha de solicitud                          |
| `LinkToObj`         | `int`                  | `4`          | Vinculados a                                |
| `OriginNum`         | `int`                  | `11`         | Pedido vinculado                            |
| `Comments`          | `nvarchar`             | `254`        | Comentarios                                 |

#### Tabla: `@SOLI_PROD_DET`

| **Campo**           | **Tipo de Datos**       | **Longitud** | **Descripción**                             |
|----------------------|-------------------------|--------------|---------------------------------------------|
| `ItemType`          | `int`                  | `4`          | Tipo:<br> - `290`: Recurso<br> - `4`: Artículo |
| `ItemCode`          | `nvarchar`             | `50`         | Número del artículo                         |
| `ItemName`          | `nvarchar`             | `100`        | Descripción del artículo                    |
| `BaseQty`           | `decimal`              | `21,6`       | Cantidad base                               |
| `PlannedQty`        | `decimal`              | `21,6`       | Cantidad requerida                          |
| `wareHouse`         | `nvarchar`             | `8`          | Almacén                                     |
| `IssueType`         | `nvarchar`             | `1`          | Método de emisión:<br> - `M`: Manual<br> - `B`: Notificación |
| `Costo_Inicial`     | `decimal`              | `21,6`       | Costo inicial                               |
| `Costo_Inicial2`    | `decimal`              | `21,6`       | Costo inicial 2  
