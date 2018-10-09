
var xEmp = 2; var yEmp = 1; var T = 80;
var lineV; var lineH; var rectangle;

var images = [
    { key: 'arrow_right', value: '../Content/img/arrow_right.png', width: T, height: T, },
    { key: 'arrow_left', value: '../Content/img/arrow_left.png', width: T, height: T, },
    { key: 'caries_central', value: '../Content/img/caries_central.png', width: T, height: T, },
    { key: 'caries_derecha', value: '../Content/img/caries_derecha.png', width: T, height: T, },
    { key: 'caries_izquierda', value: '../Content/img/caries_izquierda.png', width: T, height: T, },
    { key: 'caries_arriba', value: '../Content/img/caries_arriba.png', width: T, height: T, },
    { key: 'caries_abajo', value: '../Content/img/caries_abajo.png', width: T, height: T, },
    { key: 'item', value: '../Content/img/diente.png', width: T, height: T, },
    { key: 'panel', value: '../Content/img/panel.png', width: T, height: T, },
    { key: 'save_button', value: '../Content/img/save_button.png', width: T, height: T, },
    { key: 'background', value: '../Content/img/background.png', width: T, height: T, },
];

var init_config = {
    "dientes": [],
    "sim_defaults": [],
    "simbolos": []
};


var game = new Phaser.Game(21 * T, 10 * T, Phaser.CANVAS, 'odontograma', { preload: preload, create: create, render: render, update: update });

function preload() {

    //this.load.crossOrigin = 'Anonymous';

    images.forEach(o => {
        game.load.image(o.key, o.value, o.width, o.height);
    });

    var id = 1;

    $.ajax({
        async: false,
        url: 'http://localhost:58409/Home/Simbolos',
        method: 'post',
        data: JSON.stringify({ id: id }),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data.length != 0) {
                init_config.simbolos = data;
            }
        },
        error: function (ex) {
            alert(ex.responseText);
        }
    });

    //  Load the Google WebFont Loader script
    game.load.script('webfont', '/Scripts/US/webfont.js');

}

function create() {

    game.add.image(0, 0, 'background');
    var save_button = game.add.sprite(0 * T, 0 * T, 'save_button');
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

    //Agregando los dientes
    for (var i = 1; i <= 16; i++) {
        addDiente(i, 1);
        if (i > 3 && i <= 13) {
            addDiente(i, 2);
            addDiente(i, 3);
        }
        addDiente(i, 4);
    }

    lineV = new Phaser.Line(T * (xEmp + 8), T * yEmp, T * (xEmp + 8), T * (yEmp + 4));
    lineH = new Phaser.Line(T * xEmp, T * (yEmp + 2), T * (xEmp + 16), T * (yEmp + 2));

    //Agregando las opciones

    //Caries
    //debugger

    game.add.sprite(T * (xEmp + 4), T * (yEmp + 5), 'panel');

    /*init_config.sim_defaults.forEach(o => {

    });*/

    item = game.add.sprite(T * (xEmp + 4), T * (yEmp + 5), 'caries_central');
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableSnap(T, T, false, true);
    item.events.onInputDown.add(DuplicateAndDrag, this);
    //item.events.onInputOver.add(Nombre, this);

    item = game.add.sprite(T * (xEmp + 4), T * (yEmp + 6), 'caries_derecha');
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableSnap(T, T, false, true);
    item.events.onInputDown.add(DuplicateAndDrag, this);
    //item.events.onInputOver.add(Nombre, this);

    item = game.add.sprite(T * (xEmp + 4), T * (yEmp + 7), 'caries_izquierda');
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableSnap(T, T, false, true);
    item.events.onInputDown.add(DuplicateAndDrag, this);
    //item.events.onInputOver.add(Nombre, this);

    item = game.add.sprite(T * (xEmp + 5), T * (yEmp + 5), 'caries_arriba');
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableSnap(T, T, false, true);
    item.events.onInputDown.add(DuplicateAndDrag, this);
    //item.events.onInputOver.add(Nombre, this);

    item = game.add.sprite(T * (xEmp + 5), T * (yEmp + 6), 'caries_abajo');
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableSnap(T, T, false, true);
    item.events.onInputDown.add(DuplicateAndDrag, this);
    //item.events.onInputOver.add(Nombre, this);

}

function save_up() {
    //console.log(init_config.simbolos);
    //Armar JSON leyendo las posiciones de cada diente, y si tiene enfermedades (simbolos) puestos encima, agregarlo al array

    console.log(init_config.simbolos);
    var simbolos = [];

    /*init_config.dientes.forEach(o => {
        game.world.forEach(function (item) {

            if (item.x == o.x && item.y == o.y && item.data.tipo==="S") {
                simbolos.push({ sNombreDiente: 0, sDescripcion: 0 });
            }

        });
    });

    console.log(simbolos);

    /*game.world.forEach(function (item) {

        console.log(item);

    });*/
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
    var tmpItem = game.add.sprite(game.input.mousePointer.x, game.input.mousePointer.y, item.generateTexture());
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
    //debugger
    /*$.ajax( "http://wbsrv.usuracero.gob.ni/test/Home/AllCitas" )
        .done(function() {
            alert( "success" );
        })
        .fail(function() {
            alert( "error" );
        })
        .always(function() {
            alert( "complete" );
        });*/

    //validating: 1 -- que no se busque a si mismo
    //tipo: S -- simbolo
    item.data.validating = 1;
    var encontrado = 0;
    game.world.forEach(function (it) {
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
    item = game.add.sprite(T * (xEmp - 1) + T * i, T * (y + yEmp - 1), 'item');
    dentText = game.add.text(T * (xEmp - 1) + T * i + 33, T * (y + yEmp - 1) + T - 2, '');

    dentText.anchor.setTo(0.5);
    dentText.font = 'Arial';
    dentText.fontSize = 14;
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
            var tmpItem = game.add.sprite(T * (xEmp - 1) + T * i, T * (y + yEmp - 1), o.sDescripcion);
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
