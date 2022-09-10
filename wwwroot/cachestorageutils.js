//-------------------------------------------------------------
// Browser cache storage utilities
//-------------------------------------------------------------
async function deleteRequestsFromCache(cacheNameStr, requestUrlRegexStr) {

    console.log(`deleteRequestsFromCache(${cacheNameStr}, ${requestUrlRegexStr}`);

    let cache = await caches.open(cacheNameStr);
    if (cache) {

        let cacheObjects = await cache.keys();
        if (cacheObjects) {

            let regex = new RegExp(requestUrlRegexStr);
            let result = true;

            cacheObjects.forEach(cacheObject => {

                if (regex.exec(cacheObject.url)) {

                    result &&= cache.delete(cacheObject);
                }
            });

            return result;
        }
    }

    return false;
}

async function deleteRequestsFromAllCaches(requestUrlRegexStr) {

    console.log(`deleteRequestsFromAllCaches(${requestUrlRegexStr}`);

    let cacheKeys = await caches.keys();
    if (cacheKeys) {

        let result = true;
        cacheKeys.forEach(cacheNameStr => {

            result &&= deleteRequestsFromCache(cacheNameStr, requestUrlRegexStr);
        });

        return result;
    }

    return false;
}

export {
    deleteRequestsFromCache, deleteRequestsFromAllCaches
};
