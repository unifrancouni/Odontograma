
var xEmp = 2; var yEmp = 2; var T = 50;
var lineV; var lineH; var rectangle;

var images = [
    { key: 'item', value: 'http://localhost:51713/Content/img/diente.png', width: T, height: T, },
    { key: 'panel', value: 'http://localhost:51713/Content/img/panel.png', width: T, height: T, },
    { key: 'save_button', value: 'http://localhost:51713/Content/img/save_button.png', width: T, height: T, },
    { key: 'print_button', value: 'http://localhost:51713/Content/img/print_button.png', width: T, height: T, },
    { key: 'background', value: 'http://localhost:51713/Content/img/background.png', width: T, height: T, },
];

var init_config = {
    "dientes": [],
    "sim_defaults": [],
    "simbolos": [],
    "simbolos_incompatibles": []
};


function readTextFile(file, callback) {
    var rawFile = new XMLHttpRequest();
    rawFile.overrideMimeType("application/json");
    rawFile.open("GET", file, true);
    rawFile.onreadystatechange = function () {
        if (rawFile.readyState === 4 && rawFile.status == "200") {
            callback(rawFile.responseText);
        }
    }
    rawFile.send(null);
}

//usage:
readTextFile("http://localhost:52124/Content/Jsons/simbolos_incompatibles_placa.json", function (text) {
    //debugger
    //var data = JSON.parse(text);
    init_config.simbolos_incompatibles = JSON.parse(text);
});


var game = new Phaser.Game(21 * T, 11 * T, Phaser.CANVAS, 'placagrama', { preload: preload, create: create, render: render, update: update });

function preload() {

    var id = $("#iOdi").val();

    $.ajax({
        async: false,
        url: '/PlacagramaDetalle/Detalle',
        method: 'post',
        data: JSON.stringify({ id: id }),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data != null) {
                if (data.length != 0) {
                    //debugger
                    init_config.simbolos = data;
                }
            }
        },
        error: function (ex) {
            alert(ex.responseText);
        }
    });

    $.ajax({
        async: false,
        url: '/PlacagramaDetalle/Simbolos',
        method: 'post',
        //data: JSON.stringify({ id: id }),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data != null) {
                if (data.length != 0) {
                    init_config.sim_defaults = data;
                }
            }
        },
        error: function (ex) {
            alert(ex.responseText);
        }
    });

    init_config.sim_defaults.forEach(o => {
        images.push({ key: o.sDescripcion, value: o.sPathImage, width: T, height: T, });
    });

    //this.load.crossOrigin = 'Anonymous';
    images.forEach(o => {
        game.load.image(o.key, o.value, o.width, o.height);
    });

    //  Load the Google WebFont Loader script
    game.load.script('webfont', '/js/us/webfont.js');

}

var grupo_dientes;
var grupo_simbolos;
var grupo_tools;
var save_button;
var print_button;
var descriptionText;
var areas_afectadas = [];
var dientes_ausentes = 0;
var indice_oleary = 0;

function create() {

    game.add.image(0, 0, 'background');
    save_button = game.add.sprite(0.2 * T, 0.2 * T, 'save_button');
    print_button = game.add.sprite(0.4 * T + 35, 0.2 * T, 'print_button');
    save_button.inputEnabled = true;
    print_button.inputEnabled = true;
    save_button.input.useHandCursor = true;
    print_button.input.useHandCursor = true;

    // evento click de boton Save
    print_button.events.onInputUp.add(print_up, this);
    save_button.events.onInputUp.add(save_up, this);

    //Lineas divisorias
    lineV = new Phaser.Line(T * (xEmp + 8), T * yEmp, T * (xEmp + 8), T * (yEmp + 4) + 3);
    lineH = new Phaser.Line(T * xEmp, T * (yEmp + 2) + 3, T * (xEmp + 16), T * (yEmp + 2) + 3);


    //Panel de opciones
    game.add.sprite(T * (xEmp + 4), T * (yEmp + 6), 'panel');


    //Crear grupos de sprites para recorrerlos a futuro
    grupo_dientes = game.add.group(); //back layer
    grupo_tools = game.add.group(); //front layer
    grupo_simbolos = game.add.group(); //mid layer

    //Agregando los dientes
    for (var i = 1; i <= 16; i++) {
        addDiente(i, 1);
        if (i > 3 && i <= 13) {
            addDiente(i, 2);
            addDiente(i, 3);
        }
        addDiente(i, 4);
    }

    llenarPanel(0);

    //Porcentaje % de placas (Índice de O'Leary)
    //Texto descriptivo de %
    descriptionText = game.add.text(T * (xEmp + 13), T * (yEmp - 1), 'Indice de O\'Leary: 100%');
    descriptionText.font = 'Arial';
    descriptionText.fontSize = 15;

    //Función que calcula el índice O'Leary
    IndiceOleary();
    
    //debugger
    console.log(areas_afectadas);
    console.log(dientes_ausentes);
    console.log(indice_oleary.toFixed(2));

}

function IndiceOleary() {
    //Cálculo
    dientes_ausentes = 0;
    areas_afectadas = [];
    init_config.simbolos.forEach(o => {
        if (o.sDescripcion.includes("caries"))
            addElement(o.sNombreDiente);
        else
            dientes_ausentes++;
    });
    indice_oleary = (areas_afectadas.length * 100) / (32*5 - dientes_ausentes*5);
    descriptionText.text = 'Indice de O\'Leary: ' + indice_oleary.toFixed(2) + '% Placa';
}

//Función que agrega a un array sin repetir
function addElementAsGrupBy(item) {
    //debugger
    if (!areas_afectadas.includes(item))
        areas_afectadas.push(item);
}

//Función que agrega a un array
function addElement(item) {
    //debugger
    areas_afectadas.push(item);
}


var public_pagina = 1;
var encontrado = 0;

function llenarPanel(increment) {
    //debugger
    //Si en la pagina : public_pagina + increment, no hay nada, entonces no hacer nada
    encontrado = 0;

    init_config.sim_defaults.forEach(o => {
            init_config.sim_defaults.forEach(o => {
                if (o.tipo === "T") {
                    if (o.nPagina == (public_pagina + increment)) {
                        encontrado = 1;
                    }
                }
            });
        });
   


    if (!encontrado)
        return;

    public_pagina += increment;

    //debugger
    //Borrar elementos actuales del panel
    for (i = 0; 10 > i; i++) { //Ciclo porque pasaba de que si se hace solo una vez, no se borran todos (bug de phaser)
        grupo_tools.forEach(function (it) {
            it.destroy();
        });
    }

    //debugger
    //Agregar los simbolos disponibles al panel
    i = 4;
    j = 6;
    //debugger

        init_config.sim_defaults.forEach(o => {
            //debugger
            if (o.tipo === "T") {
                if (o.nPagina == public_pagina) {
                    item = grupo_tools.create(T * (xEmp + i), T * (yEmp + j), o.sDescripcion);
                    item.inputEnabled = true;
                    item.input.useHandCursor = true;
                    item.input.enableSnap(T, T, false, true);
                    item.events.onInputDown.add(DuplicateAndDrag, this);
                    item.data = o;
                }
                j++;
                if (j == 9) {
                    j = 6;
                    i++;
                }
                if (i == 12) {
                    i = 4;
                    j = 6
                }
            }
        });

}


function save_up() {
    //console.log(init_config.simbolos);
    //Armar JSON leyendo las posiciones de cada diente, y si tiene enfermedades (simbolos) puestos encima, agregarlo al array

    console.log(JSON.stringify(init_config.simbolos));

    //debugger
    var oID = $("#iOdi").val();
    var jsonSend = { oId: oID.toString(), detail: JSON.stringify(init_config.simbolos) };

    //debugger
    $.ajax({
        async: false,
        url: '/PlacagramaDetalle/SavePlacagramaDetalle',
        method: 'post',
        data: JSON.stringify(jsonSend),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            /*if (data.length != 0) {
                init_config.simbolos = data;
            }*/
            if (data == 1)
                alert('Guardado exitosamente.');
            else
                alert('Error al guardar.');
        },
        error: function (ex) {
            alert(ex.responseText);
        }
    });

}

function print_up() {
    var new_canvas = document.createElement("canvas");
    new_canvas.width = 1050;
    new_canvas.height = 360;

    var canvas_get = document.getElementsByTagName('canvas')[0];

    var ctx = new_canvas.getContext("2d");
    ctx.drawImage(canvas_get, 0, 0);

    var dataUrl = new_canvas.toDataURL();
    var windowContent = '<!DOCTYPE html>';
    windowContent += '<html>'
    windowContent += '<head><title>Print canvas</title></head>';
    windowContent += '<body>'
    windowContent += $('#info_paciente').html();
    windowContent += '<img src="' + dataUrl + '">';
    windowContent += '</body>';
    windowContent += '</html>';
    var printWin = window.open('', '', 'width=1050,height=500');
    printWin.document.open();
    printWin.document.write(windowContent);
    printWin.document.close();
    printWin.focus();
    printWin.print();
    printWin.close();
    return;
}

function render() {

    /*game.debug.text('X: '+game.input.mousePointer.x, 100, 560);
    game.debug.text('Y: '+game.input.mousePointer.y, 280, 560);*/
    game.debug.geom(lineV, '#000');
    game.debug.geom(lineH, '#000');

}

function update() {


}

/*function Posicion(item){
    text.text = ':: '+item.data.x+','+item.data.y;
}*/

function DuplicateAndDrag(item) {
    //debugger
    var tmpItem = grupo_simbolos.create(game.input.mousePointer.x-25, game.input.mousePointer.y-25, item.generateTexture());

    tmpItem.inputEnabled = true;
    tmpItem.input.enableDrag();
    tmpItem.input.enableSnap(T, T, false, true);
    //tmpItem.anchor.setTo(0.5);
    tmpItem.input.startDrag(game.input.activePointer);
    tmpItem.events.onDragStop.add(ValidationDrop, this);

    var tipo_nuevo = "";
    if (item.data.tipo === "T")
        tipo_nuevo = "S";
    if (item.data.tipo === "A")
        tipo_nuevo = "V";

    tmpItem.data = { tipo: tipo_nuevo, sidentifier: uniqueID(), nPlacagramaID: $("#iOdi").val(), nPlacagramaDetalleID: 0, sNombreDiente: null, sDescripcion: item.key };
    init_config.simbolos.push(tmpItem.data);
}

function ValidationDrop(item) {
    //validating: 1 -- que no se busque a si mismo
    //tipo: S -- simbolo
    item.data.validating = 1;
    var encontrado = 0;

    if (item.data.tipo === "S") {
        grupo_dientes.forEach(function (it) {
            //debugger
            if (it.x == item.x && it.y == item.y && it.data.validating != 1) {
                encontrado = 1;
                item.data.validating = 0;

                if (it.data.Nombre != undefined)
                    item.data.sNombreDiente = it.data.Nombre;

                //Encontrar si existe, el nPlacagramaDetalleID, modificar los valores
                init_config.simbolos.forEach(o => {
                    //debugger
                    if (o.nPlacagramaDetalleID == item.data.nPlacagramaDetalleID && o.sidentifier === item.data.sidentifier) {
                        if (item.data.sNombreDiente != undefined) {
                            o.sNombreDiente = item.data.sNombreDiente;
                            console.log(o.sNombreDiente);
                        }
                    }
                });

            }
        });
    }
    if (item.data.tipo === "V") {
        grupo_espacios.forEach(function (it) {
            if (it.x == item.x && it.y == item.y && it.data.validating != 1) {
                encontrado = 1;
                item.data.validating = 0;

                if (it.data.Nombre != undefined)
                    item.data.sNombreDiente = it.data.Nombre;

                //Encontrar si existe, el nPlacagramaDetalleID, modificar los valores
                init_config.simbolos.forEach(o => {
                    //debugger
                    if (o.nPlacagramaDetalleID == item.data.nPlacagramaDetalleID && o.sidentifier === item.data.sidentifier) {
                        if (item.data.sNombreDiente != undefined) {
                            o.sNombreDiente = item.data.sNombreDiente;
                            console.log(o.sNombreDiente);
                        }
                    }
                });

            }
        });
    }
    if (encontrado == 0) {
        //Eliminar del init_config la primer ocurrencia del nPlacagramaDetalleID, sNombreDiente, sDescripcion del item
        init_config.simbolos.forEach(o => {
            if (o.sidentifier === item.data.sidentifier && o.nPlacagramaDetalleID === item.data.nPlacagramaDetalleID && o.sNombreDiente === item.data.sNombreDiente && o.sDescripcion === item.data.sDescripcion) {
                init_config.simbolos.splice(init_config.simbolos.indexOf(o), 1); //Eliminar el elemento current
            }
        });
        item.destroy();
    }
    else {
        //Diente encontrado, entonces validar compatibilidad con demas simbolos
        var diente = item.data.sNombreDiente;
        var simbolo = item.data.sDescripcion; 
        var incompatibilidad_encontrada = 0;

        if (!item.data.sNombreDiente.includes("E")) {

            var diente_actual = parseInt(diente); //Convertimos a entero
            var diente_incompatible = (diente_actual < 51) ? diente_actual + 40 : diente_actual - 40;

            init_config.simbolos.forEach(o => {
                if (o != undefined) {
                    if (!o.sNombreDiente.includes("E")) {
                        if (o.sNombreDiente === diente_incompatible.toString() && o.sidentifier != item.data.sidentifier) {
                            //debugger
                            incompatibilidad_encontrada = 1;
                            alert("Incompatibilidad de dientes encontrada");
                        }
                    }
                }
            });
            init_config.simbolos.forEach(o => {
                if (o != undefined) {
                    if (!o.sNombreDiente.includes("E")) {
                        if (o.sNombreDiente === diente && o.sidentifier != item.data.sidentifier) {
                            init_config.simbolos_incompatibles.forEach(i => {
                                //debugger
                                console.log(o);
                                if ((o.sDescripcion === i.simbolo1 && simbolo === i.simbolo2) || (o.sDescripcion === i.simbolo2 && simbolo === i.simbolo1)) {
                                    //debugger
                                    incompatibilidad_encontrada = 1;
                                    alert("Incompatibilidad de simbolos encontrada");
                                }
                            });
                        }
                    }
                }
            });
        }
        else {
            //debugger
            //Con solo que el diente tenga algo es incompatible, ya que solo se permite una abreviatura por espacio
            init_config.simbolos.forEach(o => {
                if (o != undefined) {
                    if (o.sNombreDiente.includes("E")) {
                        if (o.sNombreDiente === diente && o.sidentifier != item.data.sidentifier) {
                            //debugger
                            incompatibilidad_encontrada = 1;
                            alert("Solo se permite una abreviatura por espacio");
                        }
                    }
                }
            });
        }
        
        if (incompatibilidad_encontrada) {
            //Eliminar del init_config la primer ocurrencia del nPlacagramaDetalleID, sNombreDiente, sDescripcion del item
            init_config.simbolos.forEach(o => {
                if (o.sidentifier === item.data.sidentifier && o.nPlacagramaDetalleID === item.data.nPlacagramaDetalleID && o.sNombreDiente === item.data.sNombreDiente && o.sDescripcion === item.data.sDescripcion) {
                    init_config.simbolos.splice(init_config.simbolos.indexOf(o), 1); //Eliminar el elemento current
                }
            });
            item.destroy();
        }
        else
            item.bringToTop();

    }

    IndiceOleary();

}

function Nombre(item) {
    text.text = 'Nombre de diente: ' + item.data.Nombre;
}

function obtenerNombre(i, y) {
    var cuadrante = obtenerCuadrante(i, y);
    var numero = obtenerNumero(i);
    return '' + cuadrante + '' + numero
}

function obtenerCuadrante(i, y) {
    // <= >=
    switch (y) {
        case 1:
            if (i >= 1 && i <= 8)
                return 1;
            else if (i >= 9 && i <= 16)
                return 2;
            else
                return NaN;
        case 2:
            if (i >= 4 && i <= 8)
                return 5;
            else if (i >= 9 && i <= 13)
                return 6;
            else
                return NaN;
        case 3:
            if (i >= 4 && i <= 8)
                return 8;
            else if (i >= 9 && i <= 13)
                return 7;
            else
                return NaN;
        case 4:
            if (i >= 1 && i <= 8)
                return 4;
            else if (i >= 9 && i <= 16)
                return 3;
            else
                return NaN;
        default:
            return NaN;
    }
}

function obtenerNumero(i) {
    if (i >= 1 && i <= 8)
        return 9 - i;
    else if (i >= 9 && i <= 16)
        return i - 8;
    else
        return NaN;
}

function addDiente(i, y) {
    var x = 0;
    item = grupo_dientes.create(T * (xEmp - 1) + T * i, T * (y + yEmp - 1), 'item');
    dentText = game.add.text(T * (xEmp - 1) + T * i + 25, T * (y + yEmp - 1) + T + 1, '');

    dentText.anchor.setTo(0.5);
    dentText.font = 'Arial';
    dentText.fontSize = 10;
    //item.scale.setTo(T, T);
    item.data = {
        tipo: "D",
        Nombre: obtenerNombre(i, y),
        x: item.x,
        y: item.y
    };

    init_config.dientes.push(item.data);

    dentText.text = item.data.Nombre;
    item.inputEnabled = true;
    //item.input.useHandCursor = true;
    //item.input.enableDrag();
    item.input.enableSnap(T, T, false, true);
    //item.events.onDragStop.add(fixLocation);
    //item.events.onInputDown.add(Nombre, this);
    //item.events.onInputOver.add(Nombre, this);
    init_config.simbolos.forEach(o => {
        if (item.data.Nombre === o.sNombreDiente) {
            var tmpItem = grupo_simbolos.create(T * (xEmp - 1) + T * i, T * (y + yEmp - 1), o.sDescripcion);
            tmpItem.inputEnabled = true;
            tmpItem.input.enableDrag();
            tmpItem.input.enableSnap(T, T, false, true);
            tmpItem.events.onDragStop.add(ValidationDrop, this);
            tmpItem.data = o;
            tmpItem.data.sidentifier = uniqueID();
        }
    });
}


function uniqueID() {
    // Math.random should be unique because of its seeding algorithm.
    // Convert it to base 36 (numbers + letters), and grab the first 9 characters
    // after the decimal.
    return '_' + Math.random().toString(36).substr(2, 9);
};

/*function fixLocation(item) {

    // Move the items when it is already dropped.
    if (item.x < 90) {
        item.x = 90;
    }
    else if (item.x > 180 && item.x < 270) {
        item.x = 180;
    }
    else if (item.x > 360) {
        item.x = 270;
    }

}*/