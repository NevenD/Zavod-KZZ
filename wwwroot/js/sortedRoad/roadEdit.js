
// Road vector layer
let roadEditStyle = new ol.style.Style({
    stroke: new ol.style.Stroke({
        color: 'red',
        lineCap: '',
        width: 4
    }),
    image: new ol.style.Circle({
        radius: 5,
        fill: new ol.style.Fill({
            color: 'red',
        }),
        stroke: new ol.style.Stroke({
            color: 'white',
            width: 2
        })
    }),
});
let roadEditVector = new ol.layer.Vector({
    source: new ol.source.Vector(),
    style: stylRoadEditFunction,
    zIndex: 100
});

map.addLayer(roadEditVector);

let drawInteraction;
let modifyDrawInteraction;
let selectInteraction;


let fetchedVectors = new ol.layer.Vector({
    source: new ol.source.Vector(),
    style: styleRoadsFunction,
    zIndex: 100
});

map.addLayer(fetchedVectors);

let snapInteraction = new ol.interaction.Snap({
    source: roadEditVector.getSource()
});
let snapFetchedVectorsInteraction = new ol.interaction.Snap({
    source: fetchedVectors.getSource()
});
//element for calculation values
let elementDOFLength = document.getElementById("ortoLengthEdit");
let elementWKT = document.getElementById("wkt");
let elementGeoJSON = document.getElementById("geojson");
let elementCoorsUnprojected = document.getElementById("coordinatesUnprojected");

let roadCode = document.getElementById("Road_Code");
let roadCategory = document.getElementById("Road_RoadCategoryID");
let roadDescription = document.getElementById("Road_Description");
let roadOfficialLength = document.getElementById("Road_SpatialNewslength");
let roadOrtoLength = document.getElementById("ortoLengthEdit");
let roadReconstructionDate = document.getElementById("Road_ReconstructionDate");
let roadReconstructionDescription = document.getElementById("Road_ReconstructionDescription");


//#region RESET INTERACTION
// Reset all interaction

let buttonResetDrawSettings = document.createElement('button');
buttonResetDrawSettings.innerHTML = '<i style="color: gray;" class="fas fa-times"></i>';
buttonResetDrawSettings.setAttribute("data-toggle", "tooltip");
buttonResetDrawSettings.setAttribute("data-placement", "right");
buttonResetDrawSettings.title = "Isključi interaktivnost";
let actionResetDraw = function (e) {
    RemoveSelectSnapDrawModifyInteraction();
};
buttonResetDrawSettings.addEventListener('click', actionResetDraw, false);
let elementResetDrawSettings = document.createElement('div');
elementResetDrawSettings.className = 'draw-reset-button ol-control';
elementResetDrawSettings.appendChild(buttonResetDrawSettings);
//#endregion

//#region DRAW INTERACTION
// Draw roads
let buttonDrawSettings = document.createElement('button');
buttonDrawSettings.innerHTML = '<i style="color: gray;" class="fas fa-pencil-alt"></i>';
buttonDrawSettings.setAttribute("data-toggle", "tooltip");
buttonDrawSettings.setAttribute("data-placement", "right");
buttonDrawSettings.title = "Izradi cestu";


let actionDraw = function (e) {

    RemoveSelectSnapDrawModifyInteraction();

    drawInteraction = new ol.interaction.Draw({
        type: 'LineString',
        style: roadEditStyle,
        source: roadEditVector.getSource()
    });

    roadEditVector.getSource().on('addfeature', function (evt) {
        if (roadEditVector.getSource().getState() === 'ready') {
            calculateLength(elementDOFLength, roadEditVector.getSource().getFeatures());
        }
    });
    map.addInteraction(drawInteraction);
    map.addInteraction(snapInteraction);
    map.addInteraction(snapFetchedVectorsInteraction);

};
buttonDrawSettings.addEventListener('click', actionDraw, false);
let elementDrawSettings = document.createElement('div');
elementDrawSettings.className = 'draw-button  ol-control';
elementDrawSettings.appendChild(buttonDrawSettings);
//#endregion

//#region EDIT INTERACTION
// Edit roads
let buttonDrawEditSettings = document.createElement('button');
buttonDrawEditSettings.innerHTML = '<i style="color: gray;" class="far fa-edit"></i>';
buttonDrawEditSettings.setAttribute("data-toggle", "tooltip");
buttonDrawEditSettings.setAttribute("data-placement", "right");
buttonDrawEditSettings.title = "Uredi cestu";

let actionDrawEdit = function (e) {
    map.removeInteraction(selectInteraction);
    map.removeInteraction(drawInteraction);

    selectInteraction = new ol.interaction.Select({
        layers: [roadEditVector]
    });
    map.addInteraction(selectInteraction);

    modifyDrawInteraction = new ol.interaction.Modify({
        features: selectInteraction.getFeatures()
    });
    map.addInteraction(snapInteraction);
    map.addInteraction(snapFetchedVectorsInteraction);
    map.addInteraction(modifyDrawInteraction);
    modifyDrawInteraction.on('modifyend', function () {
        calculateLength(elementDOFLength, roadEditVector.getSource().getFeatures());
    });

};

buttonDrawEditSettings.addEventListener('click', actionDrawEdit, false);
let elementDrawEditSettings = document.createElement('div');
elementDrawEditSettings.className = 'draw-edit-button  ol-control';
elementDrawEditSettings.appendChild(buttonDrawEditSettings);
//#endregion

//#region UNDO INTERACTION
// Undo roads
let buttonDrawUndoSettings = document.createElement('button');
buttonDrawUndoSettings.innerHTML = '<i style="color: gray;" class="fas fa-undo"></i>';
buttonDrawUndoSettings.setAttribute("data-toggle", "tooltip");
buttonDrawUndoSettings.setAttribute("data-placement", "right");
buttonDrawUndoSettings.title = "Izbriši zadnju točku";
let actionDrawUndoEdit = function (e) {

    drawInteraction.removeLastPoint();
};
buttonDrawUndoSettings.addEventListener('click', actionDrawUndoEdit, false);
let elementDrawUndoEditSettings = document.createElement('div');
elementDrawUndoEditSettings.className = 'draw-undo-button  ol-control';
elementDrawUndoEditSettings.appendChild(buttonDrawUndoSettings);
//#endregion

//#region DELETE INTERACTION
// Delete roads
let buttonDrawDeleteSettings = document.createElement('button');
buttonDrawDeleteSettings.innerHTML = '<i style="color: red;" class="far fa-trash-alt"></i>';
buttonDrawDeleteSettings.setAttribute("data-toggle", "tooltip");
buttonDrawDeleteSettings.setAttribute("data-placement", "right");
buttonDrawDeleteSettings.title = "Izbriši unos";
let actionDrawDelete = function (e) {

    let features = roadEditVector.getSource().getFeatures();
    if (features.length > 0) {
        roadEditVector.getSource().clear();
        elementDOFLength.value = "";
    }

    map.removeInteraction(drawInteraction);
    map.removeInteraction(selectInteraction);
    map.removeInteraction(modifyDrawInteraction);
    map.removeInteraction(snapInteraction);
    map.addInteraction(snapFetchedVectorsInteraction);

};
buttonDrawDeleteSettings.addEventListener('click', actionDrawDelete, false);
let elementDrawDeleteSettings = document.createElement('div');
elementDrawDeleteSettings.className = 'draw-delete-button  ol-control';
elementDrawDeleteSettings.appendChild(buttonDrawDeleteSettings);
//#endregion

//#region ADDING CONTROL TO MAP
let settingsResetDrawDeleteControl = new ol.control.Control({
    element: elementResetDrawSettings
});
let settingsDrawDeleteControl = new ol.control.Control({
    element: elementDrawDeleteSettings
});
let settingsDrawUndoControl = new ol.control.Control({
    element: elementDrawUndoEditSettings
});
let settingsDrawEditControl = new ol.control.Control({
    element: elementDrawEditSettings
});
let settingsDrawControl = new ol.control.Control({
    element: elementDrawSettings
});

map.addControl(settingsResetDrawDeleteControl);
map.addControl(settingsDrawControl);
map.addControl(settingsDrawEditControl);
map.addControl(settingsDrawUndoControl);
map.addControl(settingsDrawDeleteControl);
//#endregion

function RemoveSelectSnapDrawModifyInteraction() {
    map.removeInteraction(drawInteraction);
    map.removeInteraction(snapInteraction);
    map.addInteraction(snapFetchedVectorsInteraction);
    map.removeInteraction(selectInteraction);
    map.removeInteraction(modifyDrawInteraction);
}

function styleRoadsFunction(feature) {
    if (feature.get("KATEGORIJA") === "Lokalna") {
        return [new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'orange',
                lineCap: 'square',
                width: 3
            }),
            text: new ol.style.Text({
                font: '12px Calibri,sans-serif',
                fill: new ol.style.Fill({ color: '#000' }),
                stroke: new ol.style.Stroke({
                    color: '#fff', width: 2
                }),
                text: map.getView().getZoom() > 12 ? feature.get("OZNAKA") : ""
            })
        })]
    } else if (feature.get("KATEGORIJA") === "Županijska") {
        return [new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'green',
                lineCap: 'square',
                width: 4
            }),
            text: new ol.style.Text({
                font: '12px Calibri,sans-serif',
                fill: new ol.style.Fill({ color: '#000' }),
                stroke: new ol.style.Stroke({
                    color: '#fff', width: 2
                }),
                text: map.getView().getZoom() > 12 ? feature.get("OZNAKA") : ""
            })
        })]
    } else if (feature.get("KATEGORIJA") === "Državna") {
        return [new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'red',
                lineCap: 'square',
                width: 5
            }),
            text: new ol.style.Text({
                font: '12px Calibri,sans-serif',
                fill: new ol.style.Fill({ color: '#000' }),
                stroke: new ol.style.Stroke({
                    color: '#fff', width: 2
                }),
                text: map.getView().getZoom() > 12 ? feature.get("OZNAKA") : ""
            })
        })]
    } else if (feature.get("KATEGORIJA") === "Autocesta") {
        return [new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'magenta',
                lineCap: 'square',
                width: 6
            }),
            text: new ol.style.Text({
                font: '12px Calibri,sans-serif',
                fill: new ol.style.Fill({ color: '#000' }),
                stroke: new ol.style.Stroke({
                    color: '#fff', width: 2
                }),
                text: map.getView().getZoom() > 12 ? feature.get("OZNAKA") : ""
            })
        })]
    }
    else if (feature.get("KATEGORIJA") === "Planirana") {
        return [new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'gray',
                lineCap: 'square',
                width: 3
            }),
            text: new ol.style.Text({
                font: '12px Calibri,sans-serif',
                fill: new ol.style.Fill({ color: '#000' }),
                stroke: new ol.style.Stroke({
                    color: '#fff', width: 2
                }),
                text: map.getView().getZoom() > 12 ? feature.get("OZNAKA") : ""
            })
        })]
    } else if (feature.get("KATEGORIJA") === "Brza") {
        return [new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'red',
                lineCap: 'square',
                width: 6
            }),
            text: new ol.style.Text({
                font: '12px Calibri,sans-serif',
                fill: new ol.style.Fill({ color: '#000' }),
                stroke: new ol.style.Stroke({
                    color: '#fff', width: 2
                }),
                text: map.getView().getZoom() > 12 ? feature.get("OZNAKA") : ""
            })
        })]
    } else {
        return [new ol.style.Style({
            stroke: new ol.style.Stroke({
                color: 'gray',
                lineCap: 'square',
                width: 3
            }),
            text: new ol.style.Text({
                font: '12px Calibri,sans-serif',
                fill: new ol.style.Fill({ color: '#000' }),
                stroke: new ol.style.Stroke({
                    color: '#fff', width: 2
                }),
                text: map.getView().getZoom() > 15 ? feature.get("KATEGORIJA") : ""
            })
        })]
    }
};


function stylRoadEditFunction(feature) {
    return [new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: 'red',
            lineCap: 'square',
            width: 3
        }),
        text: new ol.style.Text({
            font: '12px Calibri,sans-serif',
            fill: new ol.style.Fill({ color: '#000' }),
            stroke: new ol.style.Stroke({
                color: '#fff', width: 2
            }),
            text: map.getView().getZoom() > 12 ? feature.get("OZNAKA") : ""
        })
    })]
}