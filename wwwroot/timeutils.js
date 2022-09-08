//-------------------------------------------------------------
// Timezone info utilities
//-------------------------------------------------------------
async function getLocalTimezoneOffset() {

    return new Date().getTimezoneOffset();
}

async function getLocalTimezoneName() {

    return Intl.DateTimeFormat().resolvedOptions().timeZone;
}

export {
    getLocalTimezoneOffset, getLocalTimezoneName
};
