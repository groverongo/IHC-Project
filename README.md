# Simulador de Touring - Instrucciones de compilación & ejecución
1. Clonar el repositorio
```
git clone https://github.com/groverongo/IHC-Project.git
```
2. Configuración de plataforma
2.1. Seleccionar el Menú ***File > Build Settings***
2.2. En menú **Plataform** seleccionar *Android*
2.3. Instalar los modulos de *Android* requeridos en caso de que lo solicite Unity.

3. Player Settings
3.1 Selecciona el Menù ***File > Build Settings>Player Settings***
3.2 Validar las siguientes configuraciones:
    - Auto Graphics API: False
    - Graphics API's: Vulkan

4. Selección de Escenas
4.1 Seleccionar el Menú ***File > Build Settings***
4.2  Utilizar el boton de Add Open Scenes para agregar y seleccionar las siguientes escenas:
    - Scenes/MenuFinalFinal
    - Scenes/Circuito
    - Scenes/TutorialRack

5. Compilación
5.1 Seleccionar el Menú ***File > Build Settings***
5.2 Conectar el dispositivo *Meta Quest 2* en modo USB Debug
5.3 Seleccionar la opcción **Build & Run**
5.4 La aplicación aparecerá en norígenes desconocidos en la interfaz del *Meta Quest 2*
