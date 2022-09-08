//-------------------------------------------------------------
// Document specific utilities
//-------------------------------------------------------------
let visibilityChangeCbAssembly;
let visibilityChangeCbMethod;

async function visibilityChangeCb() {

    let isVisible = (document.visibilityState === 'visible');
    console.log(`visibilityChangeCb: isVisible ${isVisible}`);
    await DotNet.invokeMethodAsync(visibilityChangeCbAssembly, visibilityChangeCbMethod, isVisible);
}
async function enableVisibilityChangeEvent(assemblyName, onVisibilityChangeCb) {

    visibilityChangeCbAssembly = assemblyName;
    visibilityChangeCbMethod = onVisibilityChangeCb;
    document.addEventListener('visibilitychange', visibilityChangeCb);
}
async function disableVisibilityChangeEvent() {

    visibilityChangeCbAssembly = null;
    visibilityChangeCbMethod = null;
    document.removeEventListener('visibilitychange', visibilityChangeCb);
}

export {
    enableVisibilityChangeEvent, disableVisibilityChangeEvent
};
