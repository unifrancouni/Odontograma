
var xEmp = 2; var yEmp = 1; var T = 50;
var lineV; var lineH; var rectangle;

var images = [
    { key: 'arrow_right', value: '../Content/img/arrow_right.png', width: T, height: T, },
    { key: 'arrow_left', value: '../Content/img/arrow_left.png', width: T, height: T, },
    /*{ key: 'caries_central', value: '../Content/img/caries_central.png', width: T, height: T, },
    { key: 'caries_derecha', value: '../Content/img/caries_derecha.png', width: T, height: T, },
    { key: 'caries_izquierda', value: '../Content/img/caries_izquierda.png', width: T, height: T, },
    { key: 'caries_arriba', value: '../Content/img/caries_arriba.png', width: T, height: T, },
    { key: 'caries_abajo', value: '../Content/img/caries_abajo.png', width: T, height: T, },*/
    { key: 'item', value: '../Content/img/diente.png', width: T, height: T, },
    { key: 'panel', value: '../Content/img/panel.png', width: T, height: T, },
    { key: 'save_button', value: '../Content/img/save_button.png', width: T, height: T, },
    { key: 'toggle_d', value: '../Content/img/toggle_d.png', width: T, height: T, },
    { key: 'toggle_ed', value: '../Content/img/toggle_ed.png', width: T, height: T, },
    { key: 'background', value: '../Content/img/background.png', width: T, height: T, },
];

var init_config = {
    "dientes": [],
    "sim_defaults": [],
    "simbolos": []
};


var game = new Phaser.Game(21 * T, 10 * T, Phaser.CANVAS, 'odontograma', { preload: preload, create: create, render: render, update: update });

function preload() {

    var id = 1;

    $.ajax({
        async: false,
        url: '/Odontograma/Detalle',
        method: 'post',
        data: JSON.stringify({ id: id }),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            debugger
            if (data.length != 0) {
                init_config.simbolos = data;
            }
        },
        error: function (ex) {
            debugger
            alert(ex.responseText);
        }
    });

    $.ajax({
        async: false,
        url: '/Odontograma/Sombolos',
        method: 'post',
        //data: JSON.stringify({ id: id }),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            debugger
            if (data.length != 0) {
                init_config.sim_defaults = data;
            }
        },
        error: function (ex) {
            debugger
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
    game.load.script('webfont', '/Scripts/US/webfont.js');

}

var grupo_dientes;
var grupo_simbolos;
var grupo_tools;
var switcher_bool;
var switcher;

function create() {

    game.add.image(0, 0, 'background');
    var save_button = game.add.sprite(0.5 * T, 0.4 * T, 'save_button');
    var arrow_derecha = game.add.sprite(14 * T, 7 * T, 'arrow_right');
    var arrow_izquierda = game.add.sprite(5 * T, 7 * T, 'arrow_left');
    save_button.inputEnabled = true;
    arrow_derecha.inputEnabled = true;
    arrow_izquierda.inputEnabled = true;
    save_button.input.useHandCursor = true;
    arrow_derecha.input.useHandCursor = true;
    arrow_izquierda.input.useHandCursor = true;

    // evento click de boton Save
    save_button.events.onInputUp.add(save_up, this);
    arrow_derecha.events.onInputUp.add(fn_arrowDerecha, this);
    arrow_izquierda.events.onInputUp.add(fn_arrowIzquierda, this);

    //Líneas divisorias
    lineV = new Phaser.Line(T * (xEmp + 8), T * yEmp, T * (xEmp + 8), T * (yEmp + 4) + 3);
    lineH = new Phaser.Line(T * xEmp, T * (yEmp + 2) + 3, T * (xEmp + 16), T * (yEmp + 2) + 3);


    //Switcher toggle of panel
    switcher = game.add.sprite(T * (xEmp + 3), T * (yEmp + 5), 'toggle_d');
    switcher.inputEnabled = true;
    switcher.input.useHandCursor = true;
    switcher.events.onInputUp.add(fn_switcher, this);
    switcher.data.state = true;


    //Panel de opciones
    game.add.sprite(T * (xEmp + 4), T * (yEmp + 5), 'panel');
    
    //Crear grupos de sprites para recorrerlos a futuro
    grupo_dientes = game.add.group();
    grupo_simbolos = game.add.group();;
    grupo_tools = game.add.group();

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

}



function fn_arrowDerecha() { llenarPanel(+1); }
function fn_arrowIzquierda() { llenarPanel(-1); }
function fn_switcher() {
    //debugger
    if (switcher.data.state == true) {
        switcher.loadTexture('toggle_ed', 0);
    }
    else {
        switcher.loadTexture('toggle_d', 0);
    }
    switcher.data.state = !switcher.data.state;
    llenarPanel(0);
}

var public_pagina = 1;
var encontrado = 0;

function llenarPanel(increment) {
    //debugger
    //Si en la pagina : public_pagina + increment, no hay nada, entonces no hacer nada
    encontrado = 0;
    init_config.sim_defaults.forEach(o => {
        if (o.nPagina == (public_pagina + increment)) {
            encontrado = 1;
        }
    });
    if (!encontrado)
        return;

    public_pagina += increment;

    //debugger
    //Borrar elementos actuales del panel
    for (i = 0; 4 > i; i++) { //Ciclo porque pasaba de que si se hace solo una vez, no se borran todos (bug de phaser)
        grupo_tools.forEach(function (it) {
            it.destroy();
        });
    }

    //debugger
    //Agregar los simbolos disponibles al panel
    i = 4;
    j = 5;

    if (switcher.data.state == true) {
        init_config.sim_defaults.forEach(o => {
            if (o.nPagina == public_pagina) {
                item = grupo_tools.create(T * (xEmp + i), T * (yEmp + j), o.sDescripcion);
                item.inputEnabled = true;
                item.input.useHandCursor = true;
                item.input.enableSnap(T, T, false, true);
                item.events.onInputDown.add(DuplicateAndDrag, this);
                item.data = o;
            }
            j++;
            if (j == 8) {
                j = 5;
                i++;
            }
            if (i == 12) {
                i = 4;
                j = 5
            }
        });
    }
    else {

    }

    
}

function save_up() {
    //console.log(init_config.simbolos);
    //Armar JSON leyendo las posiciones de cada diente, y si tiene enfermedades (simbolos) puestos encima, agregarlo al array

    console.log(JSON.stringify(init_config.simbolos));

    //debugger
    $.ajax({
        async: false,
        url: 'http://localhost:58409/Home/SaveOdontogramaDetalle',
        method: 'post',
        data: JSON.stringify({ json: JSON.stringify(init_config.simbolos) }),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            /*if (data.length != 0) {
                init_config.simbolos = data;
            }*/
            alert('Success '+data);
        },
        error: function (ex) {
            alert(ex.responseText);
        }
    });
    
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
    var tmpItem = grupo_simbolos.create(game.input.mousePointer.x, game.input.mousePointer.y, item.generateTexture());
    tmpItem.inputEnabled = true;
    tmpItem.input.enableDrag();
    tmpItem.input.enableSnap(T, T, false, true);
    //tmpItem.anchor.setTo(0.5);
    tmpItem.input.startDrag(game.input.activePointer);
    tmpItem.events.onDragStop.add(ValidationDrop, this);
    tmpItem.data = { tipo: "S", sidentifier: uniqueID(), nOdontogramaDetalleID: 0, sNombreDiente: null, sDescripcion: item.key };
    init_config.simbolos.push(tmpItem.data);
}

function ValidationDrop(item) {
    //validating: 1 -- que no se busque a si mismo
    //tipo: S -- simbolo
    item.data.validating = 1;
    var encontrado = 0;
    grupo_dientes.forEach(function (it) {
        if (it.x == item.x && it.y == item.y && it.data.validating != 1) {
            encontrado = 1;
            item.data.validating = 0;

            if (it.data.Nombre != undefined)
            item.data.sNombreDiente = it.data.Nombre;

            //Encontrar si existe, el nOdontogramaDetalleID, modificar los valores
            init_config.simbolos.forEach(o => {
                if (o.nOdontogramaDetalleID == item.data.nOdontogramaDetalleID && o.sidentifier===item.data.sidentifier) {
                    if (item.data.sNombreDiente != undefined) {
                        o.sNombreDiente = item.data.sNombreDiente;
                        console.log(o.sNombreDiente);
                    }
                }
            });

        }
    });
    if (encontrado == 0) {
        //Eliminar del init_config la primer ocurrencia del nOdontogramaDetalleID, sNombreDiente, sDescripcion del item
        init_config.simbolos.forEach(o => {
            if (o.sidentifier===item.data.sidentifier && o.nOdontogramaDetalleID === item.data.nOdontogramaDetalleID && o.sNombreDiente === item.data.sNombreDiente && o.sDescripcion === item.data.sDescripcion) {
                init_config.simbolos.splice(init_config.simbolos.indexOf(o), 1); //Eliminar el elemento current
            }
        });
        item.destroy();
    }
    else {
        //Diente encontrado, entonces validar compatibilidad con demas simbolos
        var diente = item.data.sNombreDiente;
        var incompatibilidad_encontrada = 0;
        init_config.simbolos.forEach(o => {
            
            if (o != undefined) {

                init_config.simbolos.forEach(q => {
                    if (q != undefined) {
                        //debugger
                        $.ajax({
                            async: false,
                            url: 'http://localhost:58409/Home/ValidarCompatibilidadDientes',
                            method: 'post',
                            data: JSON.stringify({ diente1: o.sNombreDiente, diente2: q.sNombreDiente }),
                            dataType: 'json',
                            contentType: 'application/json',
                            success: function (data) {
                                //debugger
                                if (data === 1) {
                                    incompatibilidad_encontrada = 1;
                                    alert('Incompatibilidad de dientes encontrada')
                                }
                            },
                            error: function (ex) {
                                alert(ex.responseText);
                            }
                        });
                    }
                });

                if (o.sNombreDiente === diente && o.sidentifier!=item.data.sidentifier) {
                    //debugger
                    $.ajax({
                        async: false,
                        url: 'http://localhost:58409/Home/ValidarCompatibilidadSimbolos',
                        method: 'post',
                        data: JSON.stringify({ simbolo1: o.sDescripcion, simbolo2: item.data.sDescripcion }),
                        dataType: 'json',
                        contentType: 'application/json',
                        success: function (data) {
                            //debugger
                            if (data === 1) {
                                incompatibilidad_encontrada = 1;
                                alert('Incompatibilidad de simbolos encontrada')
                            }
                        },
                        error: function (ex) {
                            alert(ex.responseText);
                        }
                    });
                }
            }

            

        });
        if (incompatibilidad_encontrada){
            //Eliminar del init_config la primer ocurrencia del nOdontogramaDetalleID, sNombreDiente, sDescripcion del item
            init_config.simbolos.forEach(o => {
                if (o.sidentifier===item.data.sidentifier && o.nOdontogramaDetalleID === item.data.nOdontogramaDetalleID && o.sNombreDiente === item.data.sNombreDiente && o.sDescripcion === item.data.sDescripcion) {
                    init_config.simbolos.splice(init_config.simbolos.indexOf(o), 1); //Eliminar el elemento current
                }
            });
            item.destroy();
        }
        else
            item.bringToTop();
    }
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
