
var xEmp=4; var yEmp=1; var T = 64;
var texto;
var lineV; var lineH;

var game = new Phaser.Game(25*T, 20*T, Phaser.CANVAS, 'phaser-example', { preload: preload, create: create, render:render, update: update});

function preload() {
    
    game.load.image('recycle', 'img/Recycle.png', T, T);
    game.load.image('item', 'img/Diente.png', T, T);
    game.load.image('caries_central', 'img/CariesCentral.png', T, T);
    game.load.image('caries_derecha', 'img/CariesDerecha.png', T, T);
    game.load.image('caries_izquierda', 'img/CariesIzquierda.png', T, T);
    game.load.image('background', 'img/background.png', 25*T, 20*T);

}

function create() {

    game.add.image(0, 0, 'background');
    game.add.sprite(T, 4*T, 'recycle');

    for (var i = 1; i <= 16; i++)
    {
        addDiente(i, 1);
        if(i>3 && i<=13){
            addDiente(i, 2);
            addDiente(i, 3);
        }
        addDiente(i, 4);

        text = game.add.text(T, T*(yEmp+5), '', { fill: '#000' });
        text.text = 'Nombre de diente: ';

    }

    lineV = new Phaser.Line(T*(xEmp+8), T*yEmp, T*(xEmp+8), T*(yEmp+4));
    lineH = new Phaser.Line(T*xEmp, T*(yEmp+2), T*(xEmp+16), T*(yEmp+2));

    //Agregando las opciones

    //Caries
    //debugger
    item = game.add.sprite(T*(xEmp-1), T*(yEmp+6), 'caries_central');
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableSnap(T, T, false, true);
    item.events.onInputDown.add(DuplicateAndDrag, this);
    //item.events.onInputOver.add(Nombre, this);

    item = game.add.sprite(T*(xEmp-1), T*(yEmp+7), 'caries_derecha');
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableSnap(T, T, false, true);
    item.events.onInputDown.add(DuplicateAndDrag, this);
    //item.events.onInputOver.add(Nombre, this);

    item = game.add.sprite(T*(xEmp-1), T*(yEmp+8), 'caries_izquierda');
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableSnap(T, T, false, true);
    item.events.onInputDown.add(DuplicateAndDrag, this);
    //item.events.onInputOver.add(Nombre, this);

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

function DuplicateAndDrag(item){
    //debugger
    var tmpItem = game.add.sprite(game.input.mousePointer.x, game.input.mousePointer.y, item.generateTexture());
    tmpItem.inputEnabled = true;
    tmpItem.input.enableDrag();
    tmpItem.input.enableSnap(T, T, false, true);
    tmpItem.input.startDrag(game.input.activePointer);
    tmpItem.events.onDragStop.add(ValidationDrop, this);
}

function ValidationDrop(item){
    //debugger
    item.data = { validating : 1 }
    if (item.x == T && item.y == 4*T){
        item.destroy();
    }
    var encontrado = 0;
    game.world.forEach(function(it) {
        if (it.x == item.x && it.y == item.y && it.data.validating != 1)
        {
            encontrado = 1;
        }
    });
    if (encontrado == 0){
        item.destroy();
    }
}

function Nombre(item){
    text.text = 'Nombre de diente: '+item.data.Nombre;
}

function obtenerNombre(i, y){
    var cuadrante = obtenerCuadrante(i,y);
    var numero = obtenerNumero(i);
    return ''+cuadrante+''+numero
}

function obtenerCuadrante(i, y){
    // <= >=
    switch(y){
        case 1:
            if (i>=1 && i<=8)
                return 1;
            else if (i>=9 && i<=16)
                return 2;
            else
                return NaN;
        case 2:
            if (i>=4 && i<=8)
                return 5;
            else if (i>=9 && i<=13)
                return 6;
            else
                return NaN;
        case 3:
            if (i>=4 && i<=8)
                return 8;
            else if (i>=9 && i<=13)
                return 7;
            else
                return NaN;
        case 4:
            if (i>=1 && i<=8)
                return 4;
            else if (i>=9 && i<=16)
                return 3;
            else
                return NaN;
        default:
            return NaN;
    }
}

function obtenerNumero(i){
    if(i>=1 && i<=8)
        return 9-i;
    else if(i>=9 && i<=16)
        return i-8;
    else
        return NaN;
}

function addDiente(i, y){
    var x = 0;
    item = game.add.sprite(T*(xEmp-1) + T*i, T*(y+yEmp-1), 'item');
    //item.scale.setTo(T, T);
    item.data = {
        Nombre: obtenerNombre(i, y),
        x: item.x,
        y: item.y
    };
    item.inputEnabled = true;
    item.input.useHandCursor = true;
    item.input.enableDrag();
    item.input.enableSnap(T, T, false, true);
    //item.events.onDragStop.add(fixLocation);
    item.events.onInputDown.add(Nombre, this);
    item.events.onInputOver.add(Nombre, this);
}

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
