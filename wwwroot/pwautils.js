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

export {
    pwaInit, showPwaInstallPrompt, isPwaInstalled
};
