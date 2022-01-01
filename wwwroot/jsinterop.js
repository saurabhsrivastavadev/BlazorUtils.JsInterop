// jsinterop.js module

//-------------------------------------------------------------
// Timezone info utilities
//-------------------------------------------------------------
async function getLocalTimezoneOffset() {

    return new Date().getTimezoneOffset();
}

async function getLocalTimezoneName() {

    return Intl.DateTimeFormat().resolvedOptions().timeZone;
}
//-------------------------------------------------------------


//-------------------------------------------------------------
// App triggered PWA install prompt
// reference : https://web.dev/customize-install/
//-------------------------------------------------------------
let pwaInstallPrompt;
let pwaIsInstalled = true;

async function pwaInit() {

    window.addEventListener('beforeinstallprompt', (e) => {

        console.log('beforeinstallprompt event');

        pwaIsInstalled = false;

        // Prevent the mini-infobar from appearing on mobile
        e.preventDefault();

        // Stash the event so it can be triggered later.
        pwaInstallPrompt = e;

        console.log("saved the pwa install prompt for app trigger.");
    });

    window.addEventListener('appinstalled', (e) => {

        console.log('appinstalled event');
        pwaIsInstalled = true;
    });
}

async function showPwaInstallPrompt() {

    if (pwaInstallPrompt) {

        pwaInstallPrompt.prompt();

        pwaInstallPrompt.userChoice.then((choiceResult) => {

            if (choiceResult.outcome === 'accepted') {
                console.log('user accepted install prompt.');
                return true;
            } else {
                console.log('user rejected install prompt.');
                return false;
            }
        });
    }
}

async function isPwaInstalled() {

    return pwaIsInstalled;
}

//-------------------------------------------------------------

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

//-------------------------------------------------------------

export {

    getLocalTimezoneOffset, getLocalTimezoneName,
    pwaInit, showPwaInstallPrompt, isPwaInstalled,
    enableVisibilityChangeEvent, disableVisibilityChangeEvent
};
